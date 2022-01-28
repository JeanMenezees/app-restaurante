import React from "react";
import ReactDOM from "react-dom";
import axios from "axios";
import PaginaInicial from "./PaginaInicial";

export default function App() {
  return <PaginaInicial mandar={mandarNomeProBanco} />;
}

function mandarNomeProBanco(nome, mesa) {
  const params = {
      "id": parseInt(mesa),
      "cliente": nome
  };

  axios
    .put(
      `https://localhost:7282/api/Mesa/AdicionarCliente?idMesa=${mesa}`,
      params
    )
    .catch((erro) => {
      console.log(erro);
    });
}
