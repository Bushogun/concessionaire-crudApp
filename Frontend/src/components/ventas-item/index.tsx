import React, { useState } from 'react';
// import { CheckBox } from '../Check-box'; 
// import { ToDoInterface } from '../../Interfaces/i-toDo';
import { MdDelete } from "react-icons/md";
import './VentasItem.css'
import { useAppDispatch } from '../../redux/hooks';
// import { fetchTodos, updateTodoStatus } from '../../utils/api-utils';
// import { API_KEY, OPERATIONS_TODOS } from '../../Api';

interface VentasItemProps {
    changeStatus: () => void; 
}

export const VentasItem: React.FC<VentasItemProps> = ({ changeStatus }) => { 
    const dispatch = useAppDispatch();
    // const [isChecked, setIsChecked] = useState(todo.isComplete);

    // const handleChangeStatus = async (checked: boolean) => {
    //     try {
    //         setIsChecked(checked);
    //         await updateTodoStatus(dispatch, `${API_KEY}${OPERATIONS_TODOS}`, todo.id, todo.isComplete, todo.title );
    //         await fetchTodos(dispatch, `${API_KEY}${OPERATIONS_TODOS}`);
    //         changeStatus(); 
    //     } catch (error) {
    //         setIsChecked(!checked);
    //         console.error('Error al cambiar el estado del todo:', error);
    //     }
    // };

    // const handleDeleteTodo = async () => {
    //     try {
    //         await fetch(`${API_KEY}${OPERATIONS_TODOS}/${todo.id}`, { method: 'DELETE' });
    //         await fetchTodos(dispatch, `${API_KEY}${OPERATIONS_TODOS}`);
    //         changeStatus();
    //     } catch (error) {
    //         console.error('Error al eliminar el todo:', error);
    //     }
    // };

    // const handleCheckBoxChange = (checked: boolean) => {
    //     setIsChecked(checked);
    //     handleChangeStatus(checked);
    // };

    return (
        <div className="ventas-item">
            {/* <CheckBox checked={isChecked} onChange={handleCheckBoxChange} /> */}
            {/* <span className={`ventas-text ${isChecked ? 'completed' : ''}`}> */}
            <span className={`ventas-text`}>
                test
                {/* {ventas.title} */}
            </span>
        </div>
    );
}
