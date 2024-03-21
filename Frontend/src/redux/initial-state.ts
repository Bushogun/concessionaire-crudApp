import { IVentas } from "../interfaces/i-ventas";
import { IVentasValue } from "../interfaces/i-ventas"; 

export interface stateVentas {
    query: string | null,
    ventas:IVentas[],
    transactions: IVentasValue | null,
    loading: Boolean;
    error: string | null;
  }
  
  
  export const initialStateVentas:stateVentas  = {
    query: '',
    ventas: [],
    transactions: null,
    loading: false,
    error: null,
  };
  
