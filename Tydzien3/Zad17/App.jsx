import { useState, useEffect } from 'react'
import "bootstrap/dist/css/bootstrap.min.css";

function App() {
  const [zgloszenia, setZgloszenia] = useState([]);

  const [imie, setImie] = useState("");
  const [nazwisko, setNazwisko] = useState("");
  const [email, setEmail] = useState("");
  const [pesel, setPesel] = useState("");
  const [egzamin, setEgzamin] = useState("");

  const [walidacjaEmail, setWalidacjaEmail] = useState(false);
  const [walidacjaPesel, setWalidacjaPesel] = useState(false);

  const [imieModyfikowane, setImieModyfikowane] = useState(false);
  const [nazwiskoModyfikowane, setNazwiskoModyfikowane] = useState(false);
  const [emailModyfikowany, setEmailModyfikowany] = useState(false);
  const [peselModyfikowany, setPeselModyfikowany] = useState(false);

  useEffect(() =>{
    if(email.includes("@") && !email.includes(" ")){
      setWalidacjaEmail(true);
      return;
    }
    setWalidacjaEmail(false);
  }, [email])

  useEffect(() =>{
    if(pesel.length === 11 && !isNaN(parseInt(pesel))){
      setWalidacjaPesel(true);
      return;
    }
    setWalidacjaPesel(false);
  }, [pesel])

  const dodajZgloszenie = () =>{
    const zgloszenie = {
      imie: imie,
      nazwisko: nazwisko,
      email: email,
      pesel: pesel,
      egzamin: egzamin,
      data: new Date(),
      godzina: new Date().getHours() + ":" + new Date().getMinutes() + ":" + new Date().getSeconds()
    }
    setZgloszenia([...zgloszenia, zgloszenie]);
    setImie("");
    setNazwisko("");
    setEmail("");
    setPesel("");
    setEgzamin("");
    setImieModyfikowane(false);
    setNazwiskoModyfikowane(false);
    setEmailModyfikowany(false);
    setPeselModyfikowany(false);
    setWalidacjaEmail(false);
    setWalidacjaPesel(false);
  }

  const usunZgloszenie = (index) =>{
    const noweZgloszenia = [...zgloszenia];
    noweZgloszenia.splice(index, 1);
    setZgloszenia(noweZgloszenia);
  }

  return (
    <>
      <div className="container">
        <div className="row">
          <input type="text" className={"form-control " + (imieModyfikowane && imie.length <= 3 ? "border-danger" : "")} placeholder="Imie..." value={imie} onChange={(e) => {setImie(e.target.value); setImieModyfikowane(true)}} />
          {imieModyfikowane && imie.length <= 3 ? <p className="text-danger">Imie musi mieć więcej niż 3 znaki</p> : null}
        </div>
        <div className="row">
          <input type="text" className={"form-control " + (nazwiskoModyfikowane && nazwisko.length <= 3 ? "border-danger" : "")} placeholder="Nazwisko..." value={nazwisko} onChange={(e) => {setNazwisko(e.target.value); setNazwiskoModyfikowane(true)}} />
          {nazwiskoModyfikowane && nazwisko.length <= 3 ? <p className="text-danger">Nazwisko musi mieć więcej niż 3 znaki</p> : null}
        </div>
        <div className="row">
          <input type="text" className={"form-control " + (emailModyfikowany && !walidacjaEmail ? "border-danger" : "")} placeholder="Email..." value={email} onChange={(e) => {setEmail(e.target.value); setEmailModyfikowany(true)}} />
          {emailModyfikowany && !walidacjaEmail ? <p className="text-danger">Email musi zawierać @ i nie może zawierać spacji</p> : null}
        </div>
        <div className="row">
          <input type="text" className={"form-control " + (peselModyfikowany && !walidacjaPesel ? "border-danger" : "")} placeholder="PESEL..." value={pesel} onChange={(e) => {setPesel(e.target.value); setPeselModyfikowany(true)}} />
          {peselModyfikowany && !walidacjaPesel ? <p className="text-danger">PESEL musi mieć 11 cyfr</p> : null}
        </div>
        <div className="row">
          <select className="form-select" value={egzamin} onChange={(e) => setEgzamin(e.target.value)}>
            <option value="" selected disabled>Wybierz egzamin</option>
            <option value="INF.02">INF.02</option>
            <option value="INF.03">INF.03</option>
            <option value="INF.04">INF.04</option>
          </select>
        </div>
        <div className="row">
          <button className="btn btn-primary" disabled={!(imie.length > 3 && nazwisko.length > 3 && walidacjaEmail && walidacjaPesel && egzamin)} onClick={dodajZgloszenie}>Zapisz</button>
        </div>
        <div className="row">
          {zgloszenia.length > 0 ? (
            <>
              <h2>Zgłoszenia: {zgloszenia.length}</h2>
              <table className="table">
                <thead>
                  <tr>
                    <th>Imie</th>
                    <th>Nazwisko</th>
                    <th>Email</th>
                    <th>PESEL</th>
                    <th>Egzamin</th>
                    <th>Data zgłoszenia</th>
                    <th>Godzina zgłoszenia</th>
                    <th></th>
                  </tr>
                </thead>
                <tbody>
                  {zgloszenia.map((zgloszenie, index) => (
                    <tr key={index}>
                      <td>{zgloszenie.imie}</td>
                      <td>{zgloszenie.nazwisko}</td>
                      <td>{zgloszenie.email}</td>
                      <td>{zgloszenie.pesel}</td>
                      <td>{zgloszenie.egzamin}</td>
                      <td>{zgloszenie.data.toLocaleDateString()}</td>
                      <td>{zgloszenie.godzina}</td>
                      <td>
                        <button className="btn btn-danger" onClick={() => usunZgloszenie(index)}>Usuń</button>
                      </td>
                    </tr>
                  ))}
                </tbody>
              </table>
            </>
          ): <p>Brak zgłoszeń</p>}
        </div>
      </div>
    </>
  )
}

export default App;