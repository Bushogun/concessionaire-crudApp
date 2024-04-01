import * as React from 'react';
import { IEditTransactions, IVentasValue } from '../../interfaces/i-ventas';
import './VentasItem.css';
import { putVenta } from '../../utils/api-utils';

import Box from '@mui/material/Box';
import Button from '@mui/material/Button';
import Typography from '@mui/material/Typography';
import Modal from '@mui/material/Modal';
import TextField from '@mui/material/TextField';
import { useAppDispatch } from '../../redux/hooks';
import { API_KEY, OPERATIONS_VENTAS } from '../../api';

const styleInput = {
    p: 0.5,
};

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

interface VentasItemProps {
    data: IVentasValue;
}

const VentasItem: React.FC<VentasItemProps> = ({ data }) => {
    const { cliente, vehiculo, fechaVenta, precioVenta, clienteId, vehiculoId, transaccionId } = data;
    const dispatch = useAppDispatch();
    const formatDate = (dateString: string): string => {
        const date = new Date(dateString);
        const day = date.getDate().toString().padStart(2, '0');
        const monthNames = ["Ene", "Feb", "Mar", "Abr", "May", "Jun", "Jul", "Ago", "Sep", "Oct", "Nov", "Dic"];
        const month = monthNames[date.getMonth()];
        const year = date.getFullYear();
        const hours = date.getHours().toString().padStart(2, '0');
        const minutes = date.getMinutes().toString().padStart(2, '0');
        const seconds = date.getSeconds().toString().padStart(2, '0');
        return `${day}/${month}/${year} - ${hours}:${minutes}:${seconds}`;
    };

    const clienteDetails = cliente ? `${cliente.nombre}` : 'Cliente no disponible';
    const clientId = cliente ? `${cliente.clienteId}` : 'Cliente no disponible';
    const formattedFechaVenta = fechaVenta ? formatDate(fechaVenta) : 'Fecha no disponible';

    const [open, setOpen] = React.useState(false);
    const [editTransaction, setEditTransaction] = React.useState<number | undefined>();
    const [editedData, setEditedData] = React.useState<IVentasValue>(data);

    const handleEditClick = (transactionId: number) => {
        setEditTransaction(transactionId);
        setOpen(true);
    };

    const handleClose = () => {
        setOpen(false);
    };

    const handleSaveClick = async () => {
        try {
            const requestBody = {
                vehiculoId: editedData.vehiculoId!,
                clienteId: editedData.clienteId!,
                precioVenta: editedData.precioVenta!
            };

            await putVenta(dispatch, `${API_KEY}${OPERATIONS_VENTAS}/${editTransaction}`, requestBody);
            handleClose();
        } catch (error) {
            console.error('Error al actualizar la venta:', error);
        }
        window.location.reload();
    };


    const handleInputChange = (key: keyof IEditTransactions, value: any) => {
        setEditedData(prevState => ({
            ...prevState,
            [key]: value,
        }));
    };

    return (
        <React.Fragment>
            <tr>
                <td className={`ventas-text`} data-cliente-id={clienteId} data-transaction-id={transaccionId}>{clientId}</td>
                <td className={`ventas-text`} data-cliente-id={clienteDetails} data-transaction-id={transaccionId}>{clienteDetails}</td>
                <td className={`ventas-text`} data-vehiculo-id={vehiculoId} data-transaction-id={transaccionId}>{vehiculoId}</td>
                <td className={`ventas-text`} data-vehiculo-id={vehiculoId} data-transaction-id={transaccionId}>{`${vehiculo?.marca} ${vehiculo?.modelo}`}</td>
                <td className={`ventas-text`} data-transaction-id={transaccionId}>{formattedFechaVenta}</td>
                <td className={`ventas-text`} data-precio-venta={precioVenta} data-transaction-id={transaccionId}>{precioVenta ? `$${precioVenta.toFixed(2)}` : ''}</td>
                <td className={`ventas-text`}><button onClick={() => handleEditClick(transaccionId!)}>Edit</button></td>
            </tr>
            <Modal
                open={open}
                onClose={handleClose}
                aria-labelledby="modal-modal-title"
                aria-describedby="modal-modal-description"
            >
                <Box sx={style}>
                    <Typography variant="h6" component="h2" gutterBottom>
                        Edit Sell
                    </Typography>
                    <TextField
                        sx={styleInput}
                        id="VehiculoID-input"
                        label="VehiculoID"
                        fullWidth
                        variant="outlined"
                        value={editedData.vehiculoId}
                        onChange={(e) => handleInputChange('vehiculoId', e.target.value)}
                    />
                    <TextField
                        sx={styleInput}
                        id="ClienteID-input"
                        label="ClienteID"
                        fullWidth
                        variant="outlined"
                        value={editedData.clienteId}
                        onChange={(e) => handleInputChange('clienteId', e.target.value)}
                    />
                    <TextField
                        sx={styleInput}
                        id="PrecioVenta-input"
                        label="PrecioVenta"
                        fullWidth
                        variant="outlined"
                        value={editedData.precioVenta}
                        onChange={(e) => handleInputChange('precioVenta', e.target.value)}
                    />
                    <Button sx={{ mt: 2 }} variant="contained" color="success" onClick={handleSaveClick} >
                        Save
                    </Button>
                </Box>
            </Modal>
        </React.Fragment>
    );
};

export default VentasItem;
