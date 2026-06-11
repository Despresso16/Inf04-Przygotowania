import { useState } from 'react'
import "bootstrap/dist/css/bootstrap.min.css";

function App() {
  const [projekty, setProjekty] = useState([
    { id: 1, tytul: "Projekt 1", kategoria: "Web", opis: "Opis projektu 1", liczbaPobran: 0 },
    { id: 2, tytul: "Projekt 2", kategoria: "Mobile", opis: "Opis projektu 2", liczbaPobran: 0 },
    { id: 3, tytul: "Projekt 3", kategoria: "Desktop", opis: "Opis projektu 3", liczbaPobran: 0 },
    { id: 4, tytul: "Projekt 4", kategoria: "Web", opis: "Opis projektu 4", liczbaPobran: 0 },
    { id: 5, tytul: "Projekt 5", kategoria: "Desktop", opis: "Opis projektu 5", liczbaPobran: 0 },
    { id: 6, tytul: "Projekt 6", kategoria: "Desktop", opis: "Opis projektu 6", liczbaPobran: 0 },
    { id: 7, tytul: "Projekt 7", kategoria: "Mobile", opis: "Opis projektu 7", liczbaPobran: 0 },
    { id: 8, tytul: "Projekt 8", kategoria: "Web", opis: "Opis projektu 8", liczbaPobran: 0 },
    { id: 9, tytul: "Projekt 9", kategoria: "Web", opis: "Opis projektu 9", liczbaPobran: 0 },
  ]);
  
  const [wyswietlWeb, setWyswietlWeb] = useState(false);
  const [wyswietlMobile, setWyswietlMobile] = useState(false);
  const [wyswietlDesktop, setWyswietlDesktop] = useState(false);
  const [filtr, setFiltr] = useState("domyślnie");

  
  const wyswietloneProjekty = projekty.filter(projekt => {
    if (wyswietlWeb && projekt.kategoria === "Web") return true;
    if (wyswietlMobile && projekt.kategoria === "Mobile") return true;
    if (wyswietlDesktop && projekt.kategoria === "Desktop") return true;
    return false;
  });
  wyswietloneProjekty.sort((a, b) => {
    if(filtr === "najwięcej") return b.liczbaPobran - a.liczbaPobran;
    if(filtr === "najmniej") return a.liczbaPobran - b.liczbaPobran;
    if(filtr === "alfabetycznie") return a.tytul.localeCompare(b.tytul);
    return 0;
  });

  const najpopularniejszyProjekt = projekty.reduce((max, projekt) => projekt.liczbaPobran > max.liczbaPobran ? projekt : max, projekty[0]);
  const liczbaWyswietlonychProjektow = wyswietloneProjekty.length;

  const pobierzProjekt = (id) => {
    const noweProjekty = projekty.map(projekt => {
      if(projekt.id === id) {
        return {...projekt, liczbaPobran: projekt.liczbaPobran + 1};
      }
      return projekt;
    });
    setProjekty(noweProjekty);
  }

  const dodajKategorie = (e, kategoria) => {
    const czyZaznaczone = e.target.checked;
    
    if(kategoria === "Web") setWyswietlWeb(czyZaznaczone);
    if(kategoria === "Mobile") setWyswietlMobile(czyZaznaczone);
    if(kategoria === "Desktop") setWyswietlDesktop(czyZaznaczone);
  };

  const sortujProjekty = (kategoria) => {
    let posortowaneProjekty = [...wyswietloneProjekty];
    setFiltr(kategoria);
    if(kategoria === "najwięcej") {
      posortowaneProjekty.sort((a, b) => b.liczbaPobran - a.liczbaPobran);
    } else if(kategoria === "najmniej") {
      posortowaneProjekty.sort((a, b) => a.liczbaPobran - b.liczbaPobran);
    } else if(kategoria === "alfabetycznie") {
      posortowaneProjekty.sort((a, b) => a.tytul.localeCompare(b.tytul));
    }
    wyswietloneProjekty = posortowaneProjekty;
  }
  return (
    <>
      <div className="container mt-4">
        <div className="row ">
          <div className="col form-check form-switch">
            <input type="checkbox" id="web" onChange={(e) => dodajKategorie(e, "Web")} className="form-check-input" />
            <label htmlFor="web" className="form-check-label">Web</label>
          </div>
          <div className="col form-check form-switch">
            <input type="checkbox" id="mobile" onChange={(e) => dodajKategorie(e, "Mobile")} className="form-check-input" />
            <label htmlFor="mobile" className="form-check-label">Mobile</label>
          </div>  

          <div className="col form-check form-switch">
            <input type="checkbox" id="desktop" onChange={(e) => dodajKategorie(e, "Desktop")} className="form-check-input" />
            <label htmlFor="desktop" className="form-check-label">Desktop</label>
          </div>
        </div>
        <div className="row">
          <p>Liczba pobrań proj. web: {projekty.filter(p => p.kategoria === "Web").reduce((sum, p) => sum + p.liczbaPobran, 0)}</p>
          <p>Liczba pobrań proj. mobile: {projekty.filter(p => p.kategoria === "Mobile").reduce((sum, p) => sum + p.liczbaPobran, 0)}</p>
          <p>Liczba pobrań proj. desktop: {projekty.filter(p => p.kategoria === "Desktop").reduce((sum, p) => sum + p.liczbaPobran, 0)}</p>
        </div>
        <div className="row ">
          <p className="fw-bold">Liczba wyświetlonych projektów: {liczbaWyswietlonychProjektow} z {projekty.length}</p>
          <select onChange={(e) => sortujProjekty(e.target.value)}>
            <option value="domyślnie">Domyślnie</option>
            <option value="najwięcej">Najwięcej pobrań</option>
            <option value="najmniej">Najmniej pobrań</option>
            <option value="alfabetycznie">Alfabetycznie A-Z</option>
          </select>
        </div>
        
        <div className="row">
          {wyswietloneProjekty.map(projekt => (
            <div className="card col-md-4" key={projekt.id}>
              <div className="card-body">
                {projekt.id === najpopularniejszyProjekt.id && <span className="badge bg-success">Najpopularniejszy</span>}
                <h5 className="card-title">{projekt.tytul}</h5>
                <p className="card-text">Kategoria: {projekt.kategoria}</p>
                <p className="card-text">Liczba pobrań: {projekt.liczbaPobran}</p>
                <button className="btn btn-primary" onClick={() => pobierzProjekt(projekt.id)}>Pobierz</button>
              </div>
            </div>
          ))}
          
          {liczbaWyswietlonychProjektow === 0 && (
            <p className="text-muted">Wlacz jaks kategorie, aby zobaczyc projekty.</p>
          )}
        </div>
      </div>
    </>
  )
}

export default App;