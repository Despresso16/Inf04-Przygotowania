import { useState } from 'react'
import "bootstrap/dist/css/bootstrap.min.css";

function App() {
  const [filmy, setFilmy] = useState([
    {
      id: 1,
      tytul: "Piraci z Karaibów",
      gatunek: "Przygodowy",
      licznikWyswietlen: 0
    },
    {
      id: 2,
      tytul: "Star Wars III",
      gatunek: "Sci-fi",
      licznikWyswietlen: 0
    },
    {
      id: 3,
      tytul: "Forrest Gump",
      gatunek: "Obyczajowy",
      licznikWyswietlen: 0
    },
    {
      id: 4,
      tytul: "Star Wars IV",
      gatunek: "Sci-fi",
      licznikWyswietlen: 0
    },
    {
      id: 5,
      tytul: "Ford v Ferrari",
      gatunek: "Wyścigowy",
      licznikWyswietlen: 0
    }
  ]);

  const [wyswietlaneFilmy, setWyswietlaneFilmy] = useState(filmy);
  const [sumaWyswietlen, setSumaWyswietlen] = useState(0);
  const [najbardziejOgladane, setNajbardziejOgladane] = useState([]);
  const [filtr, setFiltr] = useState("");
  const obejrz = (id) => {
    const noweFilmy = filmy.map(film => {
      if(film.id === id){
        film.licznikWyswietlen += 1;
      }
      return film;
    });
    noweFilmy.sort((a, b) => b.licznikWyswietlen - a.licznikWyswietlen);
    setFilmy(noweFilmy);
    filtrujFilmy(filtr);
    znajdzNajbardziejOgladane();
  }

  const znajdzNajbardziejOgladane = () => {
    let maxWyswietlen = 0;
    let najbardziejOgladane = [];
    wyswietlaneFilmy.forEach(film => {
      if(film.licznikWyswietlen > maxWyswietlen){
        maxWyswietlen = film.licznikWyswietlen;
        najbardziejOgladane = [film];
      }
      else if(film.licznikWyswietlen === maxWyswietlen){
        najbardziejOgladane.push(film);
      }
    });
    setNajbardziejOgladane(najbardziejOgladane);
  }

  const reset = () =>{
    filmy.forEach(film => film.licznikWyswietlen = 0);
    setSumaWyswietlen(0);
    setNajbardziejOgladane([]);
  }

  const filtrujFilmy = (gatunek) => {
    let noweWyswietlaneFilmy = [];
    if(gatunek === "") {
      noweWyswietlaneFilmy = filmy.sort((a, b) => b.licznikWyswietlen - a.licznikWyswietlen);
    }
    else {
      noweWyswietlaneFilmy = filmy.filter(film => film.gatunek === gatunek).sort((a, b) => b.licznikWyswietlen - a.licznikWyswietlen);
    }
    let nowaSuma = 0
    noweWyswietlaneFilmy.forEach(film => {
      if(film.licznikWyswietlen > 0){
        nowaSuma += film.licznikWyswietlen;
      }
    });
    setWyswietlaneFilmy(noweWyswietlaneFilmy);
    setSumaWyswietlen(nowaSuma);
    znajdzNajbardziejOgladane();
  }
  return (
    <>
      <h1>Lista filmów </h1>
      <p>Suma wyświetleń: {sumaWyswietlen}</p>
      <select onChange={(e) => {setFiltr(e.target.value); filtrujFilmy(e.target.value)}}>
        <option value="" selected>Wszystkie gatunki</option>
        <option value="Przygodowy">Przygodowy</option>
        <option value="Sci-fi">Sci-fi</option>
        <option value="Obyczajowy">Obyczajowy</option>
        <option value="Wyścigowy">Wyścigowy</option>
        <option value="Komedia">Komedia</option>
      </select>
      <div className = "container ">
        <div className="row">
          {wyswietlaneFilmy.length > 0 ? 
          wyswietlaneFilmy.map(film => (
           <div className={najbardziejOgladane.includes(film) ? "card col-md-4 border-warning" : "card col-md-4"} key={film.id}>
              <div className="card-body">
                  <h5 className="card-title">{film.tytul}</h5>
                  <p className="card-text">{film.gatunek}</p>
                  <button className="btn btn-primary" onClick={() => obejrz(film.id)}>Obejrz</button>
                  <p>Licznik wyświetleń: {film.licznikWyswietlen}</p>
              </div>
          </div>
          )) :
          <p>Brak filmów do wyświetlenia</p>}
        </div>
      </div>
      <button className="btn btn-secondary" onClick={reset}>Resetuj</button>
    </>
  )
}

export default App
