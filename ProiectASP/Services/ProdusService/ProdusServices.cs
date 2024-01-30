﻿using Amazon.S3.Model;
using Microsoft.EntityFrameworkCore;
using ProiectASP.Controllers;
using ProiectASP.Data;
using ProiectASP.Exceptions;
using ProiectASP.Models;
using ProiectASP.Models.DTOs;
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
            
            try
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
                    await _s3Service.UploadFileAsync($"{p.ID}.jpg", poza);
                }
            }
            catch (Exception e)
            {
                // Handle the file upload error
                Console.WriteLine($"Error uploading file:{e}");
            }
        }

        public async Task DeleteProdus(int ProdusId)
        {
            var produsToRemove = await _repository.GetProdusByID(ProdusId);
            await _repository.DeleteProdus(produsToRemove);
        }

        public async Task<IEnumerable<ProdusDTO>> GetAllProduse()
        {
            var produse = await _repository.ListProduse();

            List<ProdusDTO> prod = new List<ProdusDTO>();
            foreach (var p in produse)
            {
                prod.Add(new ProdusDTO
                {
                    Nume = p.Nume,
                    Pret = p.Pret,
                    Descriere = p.Descriere,
                    Categorie = p.Categorie,
                });
            }
            return prod;
        }


        public async Task<Produs> GetProdusById(int ProdusId)
        {
            return await _repository.GetProdusByID(ProdusId); ;
        }
        public async Task<Produs> GetProdusByNume(string NumeProdus)
        {
            return await _repository.GetProdusByNume(NumeProdus);
        }

        public async Task UpdateProdus(Produs produs)
        {
            var p = await _repository.GetProdusByID(produs.ID);

            p.Nume = produs.Nume ?? p.Nume;
            p.Pret = produs.Pret>0 ? produs.Pret:p.Pret;
            p.Descriere = produs.Descriere ?? p.Descriere;
            p.Categorie = produs.Categorie ?? p.Categorie;

            await _repository.UpdateProdus(p);
        }
    }
}
