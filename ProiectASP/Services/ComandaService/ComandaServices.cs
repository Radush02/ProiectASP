using Microsoft.EntityFrameworkCore;
using ProiectASP.Data;
using ProiectASP.Exceptions;
using ProiectASP.Models;
using ProiectASP.Models.DTOs;
using ProiectASP.Models.DTOs.ProdusDTOs;
using ProiectASP.Models.DTOs.UserDTOs;
using ProiectASP.Repositories;
using Microsoft.AspNetCore.Identity;
using ProiectASP.Repositories.ProdusRepository;

namespace ProiectASP.Services.ComandaService
{
    public class ComandaServices : IComandaServices
    {
        private readonly IComandaRepository _comandaRepository;
        private readonly UserManager<User> _userManager;
        private readonly IProdusRepository _produsRepository;
        public ComandaServices(IComandaRepository comandaRepository,UserManager<User> userManager,IProdusRepository produsRepository)
        {
            _comandaRepository = comandaRepository;
            _userManager = userManager;
            _produsRepository = produsRepository;
        }

        public async Task<IEnumerable<ComandaDTO>> GetAllComenzi()
        {
            var comenzi = await _comandaRepository.GetAllComenzi();
            var dto = new List<ComandaDTO>();
            foreach(var com in comenzi)
            {
                dto.Add(new ComandaDTO
                {
                    produs = new ProdusDTO
                    {
                        Nume = com.Produse.Nume,
                        Pret = com.Produse.Pret,
                        Descriere = com.Produse.Descriere,
                        Categorie = com.Produse.Categorie
                    },
                    user = new UserInfoDTO
                    {
                        Nume = com.Users.Nume,
                        UserName = com.Users.UserName,
                        Adresa = com.Users.AdreseLivrare.Adresa,
                        Oras = com.Users.AdreseLivrare.Oras
                    },
                    DataComenzii=com.DataComenzii,
                    cantitate=com.cantitate
                });
            }
            return dto;
        }
        public async  Task<IEnumerable<ComandaDTO>> GetComandabyId(int userId)
        {
            var comenzi = await _comandaRepository.GetComandabyId(userId);
            var dto = new List<ComandaDTO>();
            foreach (var com in comenzi)
            {
                dto.Add(new ComandaDTO
                {
                    produs = new ProdusDTO
                    {
                        Nume = com.Produse.Nume,
                        Pret = com.Produse.Pret,
                        Descriere = com.Produse.Descriere,
                        Categorie = com.Produse.Categorie
                    },
                    user = new UserInfoDTO
                    {
                        Nume = com.Users.Nume,
                        UserName = com.Users.UserName,
                        Adresa = com.Users.AdreseLivrare.Adresa,
                        Oras = com.Users.AdreseLivrare.Oras
                    },
                    DataComenzii = com.DataComenzii,
                    cantitate = com.cantitate
                });
            }
            return dto;
        }
        public async Task CreateComanda(IEnumerable<ComandaDTO> com)
        {
            var comanda = new List<Comanda>();
            foreach(var c in com)
            {
                var prodaux = await _produsRepository.GetProdusByNume(c.produs.Nume);
                var useraux = await _userManager.FindByNameAsync(c.user.UserName);
                comanda.Add(new Comanda
                {
                    DataComenzii = c.DataComenzii,
                    UserID = useraux.Id,
                    ProdusID = prodaux.ID,
                    cantitate = c.cantitate,
                    Users = useraux,
                    Produse = prodaux
                }) ;
            }
            await _comandaRepository.CreateComanda(comanda);
        }
        public async Task DeleteComanda(int comandaId)
        {
            await _comandaRepository.DeleteComanda(comandaId);
        }

    }
}
