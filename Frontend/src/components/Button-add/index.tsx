import * as React from 'react';
import Box from '@mui/material/Box';
import Button from '@mui/material/Button';
import Typography from '@mui/material/Typography';
import Modal from '@mui/material/Modal';
import TextField from '@mui/material/TextField';
import { useAppDispatch, useAppSelector } from '../../redux/hooks';
import { API_KEY, OPERATIONS_VENTAS } from '../../api';
// import { setAddTask } from '../../redux/features/toDosSlice'; 
// import { postTodo } from '../../utils/api-utils'; 

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
  const [todoInput, setTodoInput] = React.useState('');
  const handleOpen = () => setOpen(true);
  const handleClose = () => setOpen(false);
  const dispatch = useAppDispatch();

  // const todos = useAppSelector(state => state.toDosReducer.toDos);

  const handleAddClick = async () => {
    try {
      // await postTodo(dispatch, API_KEY + OPERATIONS_TODOS, { title: todoInput, isComplete: false });
      // const lastId = todos.length > 0 ? todos[todos.length - 1].id + 1 : 1;
      // dispatch(setAddTask({ id: lastId, title: todoInput, isComplete: false })); 
      handleClose();
    } catch (error) {
      console.error('Error al agregar el todo:', error);
    }
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
          <TextField sx={styleInput}
            id="VehiculoID-input"
            label="VehiculoID"
            fullWidth
            variant="outlined"
            value={todoInput}
          // onChange={(e) => setTodoInput(e.target.value)}
          />
          <TextField sx={styleInput}
            id="ClienteID-input"
            label="ClienteID"
            fullWidth
            variant="outlined"
            value={todoInput}
          // onChange={(e) => setTodoInput(e.target.value)}
          />
          <TextField sx={styleInput}
            id="ConcesionarioID-input"
            label="ConcesionarioID"
            fullWidth
            variant="outlined"
            value={todoInput}
          // onChange={(e) => setTodoInput(e.target.value)}
          />

          <TextField sx={styleInput}
            id="PrecioVenta-input"
            label="PrecioVenta"
            fullWidth
            variant="outlined"
            value={todoInput}
          // onChange={(e) => setTodoInput(e.target.value)}
          />


          <Button sx={{ mt: 2 }} variant="contained" color="success" onClick={handleAddClick}>
            Add
          </Button>
        </Box>
      </Modal>
    </div>
  );
}
