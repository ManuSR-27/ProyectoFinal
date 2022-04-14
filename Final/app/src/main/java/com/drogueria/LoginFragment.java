package com.drogueria;

import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import androidx.annotation.NonNull;
import androidx.fragment.app.Fragment;
import androidx.navigation.fragment.NavHostFragment;
import com.drogueria.databinding.FragmentLoginBinding;

public class LoginFragment extends Fragment {

    EditText editTextUsuario, editTextPwd;
private FragmentLoginBinding binding;

    @Override
    public View onCreateView(
            LayoutInflater inflater, ViewGroup container,
            Bundle savedInstanceState
    ) {


      binding = FragmentLoginBinding.inflate(inflater, container, false);
      return binding.getRoot();

    }

    public void onViewCreated(@NonNull View view, Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);

        editTextUsuario = view.findViewById(R.id.etUsuarioLogin);
        editTextPwd = view.findViewById(R.id.etPwdLogin);


        binding.buttonFirst.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Bundle bundle = new Bundle();
                String usuario =editTextUsuario.getText().toString();
                String pwd = editTextPwd.getText().toString();
                bundle.putString("usuario", usuario);
                bundle.putString("pwd",pwd);
                getParentFragmentManager().setFragmentResult("key",bundle);
                if(usuario.equals("prueba") && pwd.equals("123")) {
                    editTextUsuario.setText("");
                    editTextPwd.setText("");
                    NavHostFragment.findNavController(LoginFragment.this)
                            .navigate(R.id.action_FirstFragment_to_SecondFragment);
                }else
                {
                    editTextUsuario.setText("");
                    editTextPwd.setText("");
                    Toast.makeText(getActivity(), "Contraseña Incorrecta", Toast.LENGTH_SHORT).show();
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