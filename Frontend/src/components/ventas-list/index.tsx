import React from 'react';
import { useAppSelector } from '../../redux/hooks';
import VentasItem from '../ventas-item';
import './VentasList.css';
import { IVentasValue } from '../../interfaces/i-ventas';

export const VentasList = () => {
  const ventas = useAppSelector(state => state.ventasReducer.ventas);
  const searchQuery = useAppSelector(state => state.ventasReducer.query);

  const filteredVentas = searchQuery
    ? ventas.filter(venta =>
      venta.cliente && venta.cliente.nombre.toLowerCase().includes(searchQuery.toLowerCase())
    )
    : ventas;


  return (
    <div className="ventas-list-container">
      <div className="ventas-list">
        <div className="ventas-title-item">
          <table>
            <thead>
              <tr>
                <th className={`ventas-title-text`}>Id Cliente</th>
                <th className={`ventas-title-text`}>Cliente</th>
                <th className={`ventas-title-text`}>Id Vehiculo</th>
                <th className={`ventas-title-text`}>Vehículo</th>
                <th className={`ventas-title-text`}>Fecha</th>
                <th className={`ventas-title-text`}>Valor</th>
                <th className={`ventas-title-text`}>Opciones</th>
              </tr>
            </thead>
            <tbody>
              {filteredVentas.map((venta: IVentasValue, index: number) => (
                <VentasItem key={venta.$id ?? index} data={venta} />
              ))}
            </tbody>
          </table>
        </div>
      </div>
    </div>
  );
};

export default VentasList;
