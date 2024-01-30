using Amazon.S3.Model;
using Microsoft.EntityFrameworkCore;
using ProiectASP.Controllers;
using ProiectASP.Data;
using ProiectASP.Exceptions;
using ProiectASP.Models;
using ProiectASP.Models.DTOs.ProdusDTOs;
using ProiectASP.Repositories.ProdusRepository;
using ProiectASP.Services;
using ProiectASP.Services.AmazonS3Service;
using System;

namespace ProiectASP.Services.ProdusService
{
    public class ProdusServices : IProdusServices
    {
        private readonly IProdusRepository _repository;
        private readonly S3Service _s3Service;
        public ProdusServices(IProdusRepository repository,S3Service s3Service)
        {
            _repository = repository;
            _s3Service = s3Service;
        }
        public async Task CreateProdus(ProdusDTO produs, IFormFile poza)
        {
            
                Console.WriteLine(produs.Nume);
                Produs p = new Produs
                {
                    Nume = produs.Nume,
                    Pret = produs.Pret,
                    Descriere = produs.Descriere,
                    Categorie = produs.Categorie,
                };

                await _repository.CreateProdus(p);
                if (poza != null && poza.Length > 0)
                {
                    await _s3Service.UploadFileAsync($"{p.ID}.png", poza);
                }
        }

        public async Task DeleteProdus(int ProdusId)
        {
            var produsToRemove = await _repository.GetProdusByID(ProdusId);
            await _repository.DeleteProdus(produsToRemove);
            await _s3Service.DeleteFileAsync($"{ProdusId}.png");    
        }

        public async Task<IEnumerable<ProdusLinkDTO>> GetAllProduse()
        {
            var produse = await _repository.ListProduse();

            List<ProdusLinkDTO> prod = new List<ProdusLinkDTO>();
            foreach (var p in produse)
            {
                prod.Add(new ProdusLinkDTO
                {
                    produs = new ProdusDTO
                    {
                        Nume = p.Nume,
                        Pret = p.Pret,
                        Descriere = p.Descriere,
                        Categorie = p.Categorie,

                    },
                    linkPoza = _s3Service.GetFileUrl($"{p.ID}.png")
                });
            }
            return prod;
        }


        public async Task<ProdusLinkDTO> GetProdusById(int ProdusId)
        {
            var produs = await _repository.GetProdusByID(ProdusId);
            return new ProdusLinkDTO
            {
                produs = new ProdusDTO
                {
                    Nume = produs.Nume,
                    Pret = produs.Pret,
                    Descriere = produs.Descriere,
                    Categorie = produs.Categorie,
                },
                linkPoza = _s3Service.GetFileUrl($"{ProdusId}.png")
            };
        }
        public async Task<ProdusLinkDTO> GetProdusByNume(string NumeProdus)
        {
            var produs = await _repository.GetProdusByNume(NumeProdus);
            return new ProdusLinkDTO
            {
                produs = new ProdusDTO
                {
                    Nume = produs.Nume,
                    Pret = produs.Pret,
                    Descriere = produs.Descriere,
                    Categorie = produs.Categorie,
                },
                linkPoza = _s3Service.GetFileUrl($"{produs.ID}.png")
            };
        }

        public async Task UpdateProdus(ProdusDTO produs)
        {
            var p = await _repository.GetProdusByID(
                _repository.GetProdusByNume(produs.Nume).Result.ID);

            p.Nume = produs.Nume ?? p.Nume;
            p.Pret = produs.Pret>0 ? produs.Pret:p.Pret;
            p.Descriere = produs.Descriere ?? p.Descriere;
            p.Categorie = produs.Categorie ?? p.Categorie;

            await _repository.UpdateProdus(p);
        }
    }
}
