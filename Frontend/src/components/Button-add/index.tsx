import * as React from 'react';
import Box from '@mui/material/Box';
import Button from '@mui/material/Button';
import Typography from '@mui/material/Typography';
import Modal from '@mui/material/Modal';
import TextField from '@mui/material/TextField';
import { useAppDispatch, useAppSelector } from '../../redux/hooks';
import { API_KEY, OPERATIONS_VENTAS } from '../../api';
// import { setAddTask } from '../../redux/features/toDosSlice'; 
import { postVenta } from '../../utils/api-utils';
import { setTransactions } from '../../redux/features/ventas-slice';

const styleInput = {
  p: 0.5,
}

const style = {
  position: 'absolute' as 'absolute',
  top: '50%',
  left: '50%',
  transform: 'translate(-50%, -50%)',
  width: 400,
  bgcolor: '#ffffff',
  borderRadius: 3,
  boxShadow: 24,
  p: 4,
};

const addButtonStyle = {
  color: '#ffffff',
  fontWeight: 'bold',
  fontSize: '2rem',
  width: '5px',
  height: '60px',
  borderRadius: '100px'
};

export default function ButtonAdd() {
  const [open, setOpen] = React.useState(false);
  const [vehiculoIDInput, setVehiculoIDInput] = React.useState(0);
  const [clienteIDInput, setClienteIDInput] = React.useState(0);
  const [concesionarioIDInput, setConcesionarioIDInput] = React.useState(0);
  const [precioVentaInput, setPrecioVentaInput] = React.useState(0);
  const handleOpen = () => setOpen(true);
  const handleClose = () => setOpen(false);
  const dispatch = useAppDispatch();

  const handleAddClick = async () => {
    try {
      await postVenta(dispatch, API_KEY + OPERATIONS_VENTAS, { vehiculoId: vehiculoIDInput, clienteId: clienteIDInput, concesionarioId: concesionarioIDInput, precioVenta: precioVentaInput });
      dispatch(setTransactions({ vehiculoId: vehiculoIDInput, clienteId: clienteIDInput, concesionarioId: concesionarioIDInput, precioVenta: precioVentaInput }));
      handleClose();
    } catch (error) {
      console.error('Error al agregar la venta:', error);
    }
    window.location.reload();
  };

  return (
    <div>
      <Button variant="contained" color="success" onClick={handleOpen} sx={addButtonStyle}>
        +
      </Button>
      <Modal
        open={open}
        onClose={handleClose}
        aria-labelledby="modal-modal-title"
        aria-describedby="modal-modal-description"
      >
        <Box sx={style}>
          <Typography variant="h6" component="h2" gutterBottom>
            New Sell
          </Typography>
          <TextField
            sx={styleInput}
            id="VehiculoID-input"
            label="VehiculoID"
            fullWidth
            variant="outlined"
            value={vehiculoIDInput}
            onChange={(e) => setVehiculoIDInput(parseInt(e.target.value))}
          />
          <TextField
            sx={styleInput}
            id="ClienteID-input"
            label="ClienteID"
            fullWidth
            variant="outlined"
            value={clienteIDInput}
            onChange={(e) => setClienteIDInput(parseInt(e.target.value))}
          />
          <TextField
            sx={styleInput}
            id="ConcesionarioID-input"
            label="ConcesionarioID"
            fullWidth
            variant="outlined"
            value={concesionarioIDInput}
            onChange={(e) => setConcesionarioIDInput(parseInt(e.target.value))}
          />

          <TextField
            sx={styleInput}
            id="PrecioVenta-input"
            label="PrecioVenta"
            fullWidth
            variant="outlined"
            value={precioVentaInput}
            onChange={(e) => setPrecioVentaInput(parseFloat(e.target.value))}
          />

          <Button sx={{ mt: 2 }} variant="contained" color="success" onClick={handleAddClick}>
            Add
          </Button>
        </Box>
      </Modal>
    </div>
  );
}
