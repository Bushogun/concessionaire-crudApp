import { setLoading } from '../redux/features/ventas-slice';
import type { AppDispatch } from "../redux/store";

const fetchData = async (url: string, dispatch: AppDispatch, options?: RequestInit) => {
  try {
    dispatch(setLoading(true));
    const response = await fetch(url, options);
    if (!response.ok) {
      throw new Error(`Error al cargar datos desde ${url}`);
    }
    const data = await response.json();
    dispatch(setLoading(false));
    return data;
  } catch (error) {
    dispatch(setLoading(false));
    throw error;
  }
};

export const fetchVentas = async (dispatch: AppDispatch, requestVentas: string) => {
  return fetchData(requestVentas, dispatch);
};

export const postVenta = async (dispatch: AppDispatch, requestVentas: string, ventasInput: { vehiculoId: number, clienteId: number, concesionarioId: number, precioVenta: number }) => {

  const url = new URL(requestVentas);
  url.searchParams.append('vehiculoId', ventasInput.vehiculoId.toString());
  url.searchParams.append('clienteId', ventasInput.clienteId.toString());
  url.searchParams.append('concesionarioId', ventasInput.concesionarioId.toString());
  url.searchParams.append('precioVenta', ventasInput.precioVenta.toString());
  const options: RequestInit = {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(ventasInput)
  };

  return fetchData(url.toString(), dispatch, options);
};

export const updateTodoStatus = async (dispatch: AppDispatch, requestUrl: string, id: number,) => {
  const url = `${requestUrl}/${id}`;
  const options: RequestInit = {
    method: 'PUT',
    headers: {
      'Content-Type': 'application/json'
    },
    body: JSON.stringify({ id: id, title: title, isComplete: !isComplete })
  };
  return fetchData(url, dispatch, options);
};

