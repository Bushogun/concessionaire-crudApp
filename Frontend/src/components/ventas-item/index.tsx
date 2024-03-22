import React from 'react';
import { IVentasValue } from '../../interfaces/i-ventas';
import './VentasItem.css';

interface VentasItemProps {
    data: IVentasValue;
}

export const VentasItem: React.FC<VentasItemProps> = ({ data }) => {
    const { cliente, concesionario, vehiculo, fechaVenta, precioVenta } = data;

    // Extraer los detalles del cliente si existe
    const clienteDetails = cliente ? `${cliente.nombre} (${cliente.email})` : 'Cliente no disponible';

    // Extraer los detalles del concesionario si existe
    const concesionarioDetails = concesionario ? `${concesionario.nombre} (${concesionario.ciudad})` : 'Concesionario no disponible';
    console.log("asdas")
    return (
        <tr>
            <td className={`ventas-text`}>{clienteDetails}</td>
            <td className={`ventas-text`}>{concesionarioDetails}</td>
            <td className={`ventas-text`}>{`${vehiculo?.marca} ${vehiculo?.modelo}`}</td>
            <td className={`ventas-text`}>{fechaVenta}</td>
            <td className={`ventas-text`}>{precioVenta ? `$${precioVenta.toFixed(2)}` : ''}</td>
            <td className={`ventas-text`}>edit</td>
        </tr>
    );
}

export default VentasItem;
