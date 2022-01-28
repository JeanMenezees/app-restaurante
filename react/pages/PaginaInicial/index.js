import React, { useState } from "react";
import ReactDOM from "react-dom";

export default function PaginaInicial(props) {
  const [nome, setNome] = useState();
  const [numMesa, setNumMesa] = useState();

  return (
    <div>
      <form
        onSubmit={(event) => {
          event.preventDefault();

          props.mandar(nome, numMesa);
        }}
      >
        <input
          type={"text"}
          placeholder="Digite seu nome"
          onChange={(event) => {
            event.preventDefault();

            setNome(event.target.value);
          }}
        ></input>
        <input
          type={"text"}
          placeholder="Digite o numero da sua mesa"
          onChange={(event) => {
            event.preventDefault();

            setNumMesa(event.target.value);
          }}
        ></input>
        <button>Submit</button>
      </form>
    </div>
  );
}
