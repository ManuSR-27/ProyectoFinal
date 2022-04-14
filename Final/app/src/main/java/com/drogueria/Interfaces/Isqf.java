package com.drogueria.Interfaces;

import com.drogueria.Models.Domicilio;
import com.drogueria.Models.SQFS;

import retrofit2.Call;
import retrofit2.http.Body;
import retrofit2.http.POST;

public interface Isqf {
    @POST("SQFs")
    Call<SQFS> SQFsPost(@Body SQFS sqfs);
}
