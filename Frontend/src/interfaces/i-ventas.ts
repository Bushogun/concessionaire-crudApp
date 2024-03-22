export interface IVentas {
    $id: string;
    $values: IVentasValue[];
}

export interface IVentasValue {
    $id?: string;
    transaccionId?: number;
    vehiculoId?: number;
    clienteId?: number | undefined;
    concesionarioId?: number;
    fechaVenta?: string;
    precioVenta?: number;
    cliente?: Cliente;
    concesionario?: Concesionario;
    vehiculo?: Vehiculo;
    $ref?: string;
}

export interface Cliente {
    $id: string;
    clienteId: number;
    nombre: string;
    email: string;
    telefono: string;
    transacciones: ClienteTransacciones;
}

export interface ClienteTransacciones {
    $id: string;
    $values: Value[];
}

export interface Value {
    $ref: string;
}

export interface Concesionario {
    $id: string;
    concesionarioId: number;
    nombre: string;
    direccion: string;
    ciudad: string;
    transacciones: ConcesionarioTransacciones;
}

export interface ConcesionarioTransacciones {
    $id: string;
    $values: PurpleValue[];
}

export interface PurpleValue {
    $ref?: string;
    $id?: string;
    transaccionId?: number;
    vehiculoId?: number;
    clienteId?: number;
    concesionarioId?: number;
    fechaVenta?: string;
    precioVenta?: number;
    cliente?: Cliente;
    concesionario?: Value;
    vehiculo?: Vehiculo;
}

export interface Vehiculo {
    $id: string;
    vehiculoId: number;
    marca: string;
    modelo: string;
    anio: number;
    precio: number;
    transacciones: ClienteTransacciones;
}
