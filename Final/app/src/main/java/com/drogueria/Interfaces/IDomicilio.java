package com.drogueria.Interfaces;
import com.drogueria.Models.Domicilio;
import com.drogueria.Models.Inventario;

import java.util.List;

import retrofit2.Call;
import retrofit2.http.Body;

import retrofit2.http.POST;

public interface IDomicilio {
    @POST("Domicilios")
    Call<Domicilio> domicilioPost(@Body Domicilio domicilio);
}

