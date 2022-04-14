package com.drogueria.Interfaces;

import com.drogueria.Models.Domicilio;
import com.drogueria.Models.Inventario;

import java.util.List;

import retrofit2.Call;
import retrofit2.http.Body;
import retrofit2.http.GET;
import retrofit2.http.POST;
import retrofit2.http.Path;
import retrofit2.http.Query;

public interface IInventario {
    @POST("Inventarios")
    Call<Inventario> inventarioPost(@Body Inventario inventario);
}


