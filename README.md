# LibriApplication

## Breve descrizione

LibriApplication permette di gestire la propria collezione di libri aggiungendo recensioni, annotazioni e tenendo traccia dei periodi di lettura. Inoltre, l'app sfrutta l'API di Google Books per arricchire le informazioni sui libri.

## Installazione

- **Crea il database:**
   - Utilizza il dump disponibile in `Libri_Application.Model/database`.
   - Nome utente: manager
   - Password: a

- **Avvia il progetto:**
   - Esegui il progetto Libri_Application.App.

- **Registrazione e ottenimento del token:**
   - Registrati inserendo un'email (non utilizzata) e una password complessa (8 caratteri, maiuscola, minuscola, carattere speciale e numero).
   - Si riceverà il token che permette di creare, modificare, eliminare e cercare le tue recensioni.

- **Aggiunta e ricerca di libri:**
  - L'aggiunta e la ricerca di un libro non richiedono il token di accesso.

- **Aggiunta, modifica e ricerca di recensioni**
   - L'aggiunta, la modifica, l'eliminazione e la ricerca di una (o tutte, come meno informazioni) recensione richiede il token di accesso.
   - Non è necessaria la presenza del libro nel database per inserire la propria recensione; questo verrà aggiunto automaticamente sfruttando le API di Google Books