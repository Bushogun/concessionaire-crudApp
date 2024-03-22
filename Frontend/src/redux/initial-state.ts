import { IVentas } from "../interfaces/i-ventas";
export interface transaction {
  vehiculoId?: number;
  clienteId?: number;
  concesionarioId?: number;
  precioVenta?: number;
}

export interface stateVentas {
  query: string | null,
  ventas: IVentas[],
  transactions: transaction | null,
  loading: Boolean;
  error: string | null;
}


export const initialStateVentas: stateVentas = {
  query: '',
  ventas: [],
  transactions: null,
  loading: false,
  error: null,
};

