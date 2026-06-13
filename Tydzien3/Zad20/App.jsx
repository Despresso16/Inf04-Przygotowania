import { useState, useEffect } from 'react'
import "bootstrap/dist/css/bootstrap.min.css";
import axios from 'axios';

function App() {
  const [dane, setDane] = useState([]);
  const [ladowanie, setLadowanie] = useState(true);
  const [blad, setBlad] = useState("");

  const [widoczneKursy, setWidoczneKursy] = useState([])
  const [kategoria, setKategoria] = useState("")
  const [filtr, setFiltr] = useState("")

  const [indeksNajwOcena, setIndeksNajwOcena] = useState(-1)

  const pobieranie = async () => {
      try {
        await new Promise(resolve => setTimeout(resolve, 1500));
        const odpowiedz = await axios.get("public/kursy.json");
        setDane(odpowiedz.data);
        setWidoczneKursy(odpowiedz.data);
        if(odpowiedz.data.length === 0) {
          setBlad("Brak danych do wyświetlenia.");
        }
      } catch (error) {
        setBlad("Wystąpił błąd podczas pobierania danych.");
      } finally {
        setLadowanie(false);
      }
    };

  useEffect(() => {
    pobieranie();
  }, []);

  const ponowProbe = () =>{
    setLadowanie(true);
    setBlad("");
    pobieranie();
  }

  useEffect(() =>{
    let filtrowaneKursy = [];
    if(kategoria === "") filtrowaneKursy = [...dane]
    else{
      filtrowaneKursy = dane.filter((kurs, indeks) =>{
        return kurs.kategoria === kategoria
      })
    }
    switch(filtr){
      case "Cena rosnąco":
        filtrowaneKursy.sort((a, b) => a.cena - b.cena);
        break;
      case "Cena malejąco":
        filtrowaneKursy.sort((a, b) => b.cena - a.cena)
        break;
      case "Ocena malejąco":
        filtrowaneKursy.sort((a, b) => b.ocena - a.ocena)
        break;
      default:
        break;
    }
    setWidoczneKursy(filtrowaneKursy)

  }, [kategoria, filtr])

  useEffect(() =>{
    let indeksNajlepszejOceny = 0;
    for(let i = 1; i < widoczneKursy.length; i++){
      if(widoczneKursy[i].ocena > widoczneKursy[indeksNajlepszejOceny].ocena){
          indeksNajlepszejOceny = i
        }
    }
    setIndeksNajwOcena(indeksNajlepszejOceny)
  }, [widoczneKursy])
  

  if(ladowanie) {
      return (
        <>
        <div className='container'>
          <div className="spinner-border"></div>
          <p>Pobieranie danych...</p>
        </div>
        </>
      )
    }
    else if(blad.length > 0) {
      return(
        <>
        <h4>Wystąpił błąd podczas ładowania danych</h4>
        <p>{blad}</p>
        <button onClick={ponowProbe}>Spróbuj ponownie</button>
        </>
      )
    }
    else {
      return (
        <>
          <div className='container'>
            <div className='row'>
              <select onChange={(e) => setKategoria(e.target.value)}>
                <option selected value={""}>Wszystkie kategorie</option>
                <option value={"Programowanie"}>Programowanie</option>
                <option value={"Web"}>Web</option>
                <option value={"Bazy danych"}>Bazy danych</option>
              </select>
            </div>
            <div className='row'>
              <select onChange={(e) => setFiltr(e.target.value)}>
                <option selected value={""}>Domyślna kolejność</option>
                <option value={"Cena rosnąco"}>Cena rosnąco</option>
                <option value={"Cena malejąco"}>Cena malęjąco</option>
                <option value={"Ocena malejąco"}>Ocena malejąco</option>
              </select>
            </div>
          </div>
          <table className="table">
            <thead>
              <tr>
                <th>Tytuł</th>
                <th>Kategoria</th>
                <th>Poziom</th>
                <th>Czas {"(h)"}</th>
                <th>Cena {"(zł)"}</th>
                <th>Ocena</th>
              </tr>
            </thead>
            <tbody>
              {widoczneKursy.map((kurs, indeks) => (
                <tr key={kurs.id} className={indeks === indeksNajwOcena ? "table-success":null}>
                  <td>{kurs.tytul}</td>
                  <td>{kurs.kategoria}</td>
                  <td>{kurs.poziom}</td>
                  <td>{kurs.czasTrwania}</td>
                  <td>{kurs.cena}</td>
                  <td>{kurs.ocena}</td>
                </tr>
              ))}
            </tbody>
          </table>
          <div className='container'>
            <div className='row'>
              <p>Liczba kursów: {widoczneKursy.length}</p>
              <p>Średnia cena: {(widoczneKursy.reduce((total, kurs)=>{return total + kurs.cena}, 0) / widoczneKursy.length).toFixed(2)}</p>
              <p>Średnia ocena: {(widoczneKursy.reduce((total, kurs)=>{return total + kurs.ocena}, 0) / widoczneKursy.length).toFixed(2)}</p>
            </div>
          </div>
        </>
      )
    }
  }

export default App;