package com.drogueria.Models;

public class Inventario {
    public Integer Id;
    public String CodigoProducto;
    public String NombreProducto;
    public String Concentracion;
    public String Presentacion;
    public String FechaInventario;
    public String NoEstante;
    public String FechaVencimiento;
    public String Cantidad;

    public String getCodigoProducto() {
        return CodigoProducto;
    }

    public void setCodigoProducto(String codigoProducto) {
        CodigoProducto = codigoProducto;
    }

    public String getNombreProducto() {
        return NombreProducto;
    }

    public void setNombreProducto(String nombreProducto) {
        NombreProducto = nombreProducto;
    }

    public String getConcentracion() {
        return Concentracion;
    }

    public void setConcentracion(String concentracion) {
        Concentracion = concentracion;
    }

    public String getPresentacion() {
        return Presentacion;
    }

    public void setPresentacion(String presentacion) {
        Presentacion = presentacion;
    }

    public String getFechaInventario() {
        return FechaInventario;
    }

    public void setFechaInventario(String fechaInventario) {
        FechaInventario = fechaInventario;
    }

    public String getNoEstante() {
        return NoEstante;
    }

    public void setNoEstante(String noEstante) {
        NoEstante = noEstante;
    }

    public String getFechaVencimiento() {
        return FechaVencimiento;
    }

    public void setFechaVencimiento(String fechaVencimiento) {
        FechaVencimiento = fechaVencimiento;
    }

    public String getCantidad() {
        return Cantidad;
    }

    public void setCantidad(String cantidad) {
        Cantidad = cantidad;
    }

}
