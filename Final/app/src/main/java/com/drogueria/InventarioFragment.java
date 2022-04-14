package com.drogueria;

import android.content.Context;
import android.os.Bundle;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;
import androidx.fragment.app.Fragment;
import androidx.navigation.fragment.NavHostFragment;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.EditText;
import android.widget.Toast;


import com.drogueria.Interfaces.IDomicilio;
import com.drogueria.Interfaces.IInventario;
import com.drogueria.Models.Domicilio;
import com.drogueria.Models.Inventario;
import com.drogueria.databinding.FragmentInfoPedidoBinding;
import com.drogueria.databinding.FragmentInventarioBinding;

import org.json.JSONException;
import org.json.JSONObject;

import java.io.Console;
import java.util.ArrayList;
import java.util.List;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;
import retrofit2.Retrofit;
import retrofit2.converter.gson.GsonConverterFactory;


public class InventarioFragment extends Fragment {
    EditText etFechaRealizacion, etNumeroEstante,etCodProducto,etNombreProducto,
            etConcentracion,etPresentacion,etCantidadDisp,etValorUnitario,etFechaVencimiento;
    Context thisContext;
    private FragmentInventarioBinding binding;


    @Override
    public View onCreateView(
            LayoutInflater inflater, ViewGroup container,
            Bundle savedInstanceState
    ) {


        binding = FragmentInventarioBinding.inflate(inflater, container, false);
        return binding.getRoot();

    }
    public void onViewCreated(@NonNull View view, Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);



        etFechaRealizacion = view.findViewById(R.id.etFechaRealizacion);
        etNumeroEstante = view.findViewById(R.id.etNumeroEstante);
        etCodProducto = view.findViewById(R.id.etCodProducto);
        etNombreProducto = view.findViewById(R.id.etNombreProducto);
        etConcentracion = view.findViewById(R.id.etConcentracion);
        etPresentacion = view.findViewById(R.id.etPresentacion);
        etCantidadDisp = view.findViewById(R.id.etCantidadDisp);
        etValorUnitario = view.findViewById(R.id.etValorUnitario);
        etFechaVencimiento = view.findViewById(R.id.etFechaVencimiento);

        binding.btnGuardarInventario.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Inventario inventario = new Inventario();
                Bundle bundle = new Bundle();
                String fechaRealizacion =etFechaRealizacion.getText().toString();
                String numeroEstante =etNumeroEstante.getText().toString();
                String codProducto =etCodProducto.getText().toString();
                String nombreProducto =etNombreProducto.getText().toString();
                String concentracion =etConcentracion.getText().toString();
                String presentacion =etPresentacion.getText().toString();
                String cantidadDisponible =etCantidadDisp.getText().toString();
                String valorUnitario =etValorUnitario.getText().toString();
                String fechaVencimiento =etFechaVencimiento.getText().toString();

                bundle.putString("fechaRealizacion", fechaRealizacion);
                bundle.putString("numeroEstante", numeroEstante);
                bundle.putString("codProducto", codProducto);
                bundle.putString("nombreProducto", nombreProducto);
                bundle.putString("concentracion", concentracion);
                bundle.putString("presentacion", presentacion);
                bundle.putString("cantidadDisponible", cantidadDisponible);
                bundle.putString("valorUnitario", valorUnitario);
                bundle.putString("fechaVencimiento", fechaVencimiento);

                inventario.FechaInventario = fechaRealizacion;
                inventario.NoEstante = numeroEstante;
                inventario.CodigoProducto = codProducto;
                inventario.NombreProducto = nombreProducto;
                inventario.Concentracion = concentracion;
                inventario.Presentacion = presentacion;
                inventario.Cantidad = cantidadDisponible;
                inventario.FechaVencimiento = fechaVencimiento;

                Configuracion config = new Configuracion();


                getParentFragmentManager().setFragmentResult("key",bundle);

                if(fechaRealizacion.equals("")|| numeroEstante.equals("")|| codProducto.equals("")||
                nombreProducto.equals("")||concentracion.equals("")||presentacion.equals("")||cantidadDisponible.equals("")||
                valorUnitario.equals("")|| fechaVencimiento.equals(""))
                {
                    Toast.makeText(getActivity(), "Por favor ingresar todos los campos en el formulario", Toast.LENGTH_SHORT).show();
                }
                else
                {
                    Retrofit.Builder builder = new Retrofit.Builder()
                            .baseUrl(config.url)
                            .addConverterFactory(GsonConverterFactory.create());
                    Retrofit retrofit = builder.build();

                    IInventario iInventario = retrofit.create(IInventario.class);
                    Call<Inventario> inventarioCall = iInventario.inventarioPost(inventario);

                    inventarioCall.enqueue(new Callback<Inventario>() {
                        @Override
                        public void onResponse(Call<Inventario> call, Response<Inventario> response) {
                            int cantidad = Integer.parseInt(cantidadDisponible);
                            if(cantidad >= 10)
                            {
                                Toast.makeText(getActivity() , "Producto Registrado", Toast.LENGTH_SHORT).show();
                            }else
                            {
                                Toast.makeText(getActivity() , "El producto está proximo a acabarse y requiere ser abastecido pronto!", Toast.LENGTH_SHORT).show();
                            }
                        }
                        @Override
                        public void onFailure(Call<Inventario> call, Throwable t) {
                            Toast.makeText(getActivity() , "Ocurrió un error registrando el producto", Toast.LENGTH_SHORT).show();
                        }
                    });
                    NavHostFragment.findNavController(InventarioFragment.this)
                            .navigate(R.id.action_inventarioFragment_to_SecondFragment);
                    onDestroyView();
                }
            }
        });
    }
    @Override
    public void onDestroyView() {
        super.onDestroyView();
        binding = null;
    }
    private Context mContext;

    @Override
    public void onAttach(Context context) {
        super.onAttach(context);
        mContext = context;
    }

    @Override

    public void onDetach() {
        super.onDetach();
        mContext = null;
    }
}