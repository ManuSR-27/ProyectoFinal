package com.drogueria;

import android.os.Bundle;

import androidx.annotation.NonNull;
import androidx.fragment.app.Fragment;
import androidx.navigation.fragment.NavHostFragment;

import android.util.Log;
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
import com.google.gson.Gson;

import java.util.List;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;
import retrofit2.Retrofit;
import retrofit2.converter.gson.GsonConverterFactory;

public class InfoPedidoFragment extends Fragment {

    EditText  etConcentracionPedido, etPresentacionPedido,
            etCodProductoPedido, etValorUnitarioPedido, etCantidadPedido,etNombreProductoDomicilio,
            etNombrePedido, etApellidosPedido, etIdentificacionPedido,
            etDireccionPedido, etBarrioPedido, etTelefonoPedido, etDomiciliarioPedido;


    private FragmentInfoPedidoBinding binding;


    @Override
    public View onCreateView(
            LayoutInflater inflater, ViewGroup container,
            Bundle savedInstanceState
    ) {


        binding = FragmentInfoPedidoBinding.inflate(inflater, container, false);
        return binding.getRoot();

    }

    public void onViewCreated(@NonNull View view, Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);

        etNombreProductoDomicilio = view.findViewById(R.id.etNombreProductoDomicilio);
        etConcentracionPedido = view.findViewById(R.id.etConcentracionPedido);
        etPresentacionPedido = view.findViewById(R.id.etPresentacionPedido);
        etCodProductoPedido = view.findViewById(R.id.etCodProductoPedido);
        etCantidadPedido = view.findViewById(R.id.etCantidadPedido);
        etNombrePedido = view.findViewById(R.id.etNombrePedido);
        etApellidosPedido = view.findViewById(R.id.etApellidosPedido);
        etIdentificacionPedido = view.findViewById(R.id.etIdentificacionPedido);
        etDireccionPedido = view.findViewById(R.id.etDireccionPedido);
        etBarrioPedido = view.findViewById(R.id.etBarrioPedido);
        etTelefonoPedido = view.findViewById(R.id.etTelefonoPedido);
        etDomiciliarioPedido = view.findViewById(R.id.etDomiciliarioPedido);
        etValorUnitarioPedido = view.findViewById(R.id.etValorUnitarioPedido);

        binding.btnfinalizacionPedido.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                try{

                Domicilio domicilio = new Domicilio();
                Bundle bundle = new Bundle();

                String nombreProducto = etNombreProductoDomicilio.getText().toString();
                String concentraciónPedido = etConcentracionPedido.getText().toString();
                String presentacionPedido = etPresentacionPedido.getText().toString();
                String codProductoPedido = etCodProductoPedido.getText().toString();
                String valorUnitarioPedido = etValorUnitarioPedido.getText().toString();
                String cantidadPedido = etCantidadPedido.getText().toString();
                String nombreUsuarioPedido = etNombrePedido.getText().toString();
                String apellidosPedido = etApellidosPedido.getText().toString();
                String identificacionPedido = etIdentificacionPedido.getText().toString();
                String direccionPedido = etDireccionPedido.getText().toString();
                String barrioPedido = etBarrioPedido.getText().toString();
                String telefonoPedido = etTelefonoPedido.getText().toString();
                String domiciliarioPedido = etDomiciliarioPedido.getText().toString();

                bundle.putString("nombreProducto", nombreProducto);
                bundle.putString("concentraciónPedido", concentraciónPedido);
                bundle.putString("presentacionPedido", presentacionPedido);
                bundle.putString("codProductoPedido", codProductoPedido);
                bundle.putString("valorUnitarioPedido", valorUnitarioPedido);
                bundle.putString("cantidadPedido", cantidadPedido);
                bundle.putString("nombrePedido", nombreUsuarioPedido);
                bundle.putString("apellidosPedido", apellidosPedido);
                bundle.putString("identificacionPedido", identificacionPedido);
                bundle.putString("direccionPedido", direccionPedido);
                bundle.putString("barrioPedido", barrioPedido);
                bundle.putString("telefonoPedido", telefonoPedido);
                bundle.putString("domiciliarioPedido", domiciliarioPedido);

                domicilio.NombreProducto = nombreProducto;
                domicilio.Concentracion = concentraciónPedido;
                domicilio.Presentacion = presentacionPedido;
                domicilio.CodigoProducto = codProductoPedido;
                domicilio.Cantidad = cantidadPedido;
                domicilio.NombreUsuario = nombreUsuarioPedido;
                domicilio.ApellidosUsuario = apellidosPedido;
                domicilio.IdUsuario = identificacionPedido;
                domicilio.Direccion = direccionPedido;
                domicilio.Barrio = barrioPedido;
                domicilio.Telefono = telefonoPedido;
                domicilio.Domiciliario = domiciliarioPedido;

                Configuracion config = new Configuracion();

                getParentFragmentManager().setFragmentResult("key",bundle);
                if(nombreProducto.equals("") || concentraciónPedido.equals("")|| presentacionPedido.equals("" )||etCodProductoPedido.equals("")|| valorUnitarioPedido.equals("")||
                        cantidadPedido.equals("")|| nombreUsuarioPedido.equals("") || apellidosPedido.equals("") || identificacionPedido.equals("")||direccionPedido.equals("")||
                barrioPedido.equals("")||telefonoPedido.equals("")||  domiciliarioPedido.equals(""))
                {
                    Toast.makeText(getActivity(), "Por favor ingresar todos los campos en el formulario", Toast.LENGTH_SHORT).show();

                }else{
                    Retrofit.Builder builder = new Retrofit.Builder()
                            .baseUrl(config.url)
                            .addConverterFactory(GsonConverterFactory.create());
                    Retrofit retrofit = builder.build();

                    IDomicilio iDomicilio = retrofit.create(IDomicilio.class);
                    Call<Domicilio> domicilioCall = iDomicilio.domicilioPost(domicilio);

                    domicilioCall.enqueue(new Callback<Domicilio>() {
                        @Override
                        public void onResponse(Call<Domicilio> call, Response<Domicilio> response) {
                            Toast.makeText(getActivity() , "Pedido Registrado", Toast.LENGTH_SHORT).show();
                        }
                        @Override
                        public void onFailure(Call<Domicilio> call, Throwable t) {
                            Toast.makeText(getActivity() , "Pedido Registrado", Toast.LENGTH_SHORT).show();
                        }
                    });

                    NavHostFragment.findNavController(InfoPedidoFragment.this)
                            .navigate(R.id.action_infoPedidoFragment_to_SecondFragment);
                    onDestroyView();
                }
                }
                catch (Exception ex)
                {
                    String error = ex.getMessage();
                }
            }

        });
    }

    @Override
    public void onDestroyView() {
        super.onDestroyView();
        binding = null;
    }


}