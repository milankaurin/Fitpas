using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.CommunicationHelper
{
    public enum Operation
    { Login, 

      KreirajKlijenta,
      AzurirajKlijenta,
      ObrisiKlijenta,

      KreirajPaket,
      AzurirajPaket,
      ObrisiPaket,

      KreirajTeretanu,
      AzurirajTeretanu,
      ObrisiTeretanu,
      
      KreirajKategoriju,
      AzurirajKategoriju,
      ObrisiKategoriju,

      KreirajClanarinu,
      PretraziClanarinu,
      AzurirajClanarinu,
     
      NadjiKlijenta,
      NadjiPT,
     UcitajListuKlijenata,
     UcitajListuPaketa,
     UcitajListuTeretana,
     UcitajListuKategorija,
     UcitajListuClanarina,
        Exit,
        KreirajPT,
        ObrisiPT,
        ObrisiClanarinu,
        PretraziTeretanu,
        Logout
    }
}
