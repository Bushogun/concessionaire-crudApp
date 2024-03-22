import React, { useEffect } from 'react';
import Error from '../Error';
import Loading from '../Loading';
import { useAppSelector, useAppDispatch } from '../../redux/hooks';
import { SearchBox } from '../Search-bar';
import ButtonAdd from '../Button-add';
import './layout.css'
import { VentasList } from '../ventas-list';
import { API_KEY, OPERATIONS_VENTAS } from '../../api'
import { fetchVentas } from '../../utils/api-utils';
import { setVentas } from '../../redux/features/ventas-slice';

export const Layout = () => {
  const loading = useAppSelector(state => state.ventasReducer.loading);
  const error = useAppSelector(state => state.ventasReducer.error);
  const dispatch = useAppDispatch();

  useEffect(() => {
    const fetchInitialData = async () => {
      try {
        const ventas = await fetchVentas(dispatch, API_KEY + OPERATIONS_VENTAS);
        console.log(ventas);
        dispatch(setVentas(ventas));
      } catch (error) {
        console.error('Error fetching todos:', error);
      }
    };
    fetchInitialData();
  }, [dispatch]);

  if (loading) {
    return <Loading />;
  }

  if (error) {
    return <Error error={error} />;
  }

  return (
    <div className='container'>
      <h1>Ventas Efectudas</h1>
      <div className="container-searchbar">
        <SearchBox />
      </div>
      <VentasList />
      <ButtonAdd />
    </div>
  )
}