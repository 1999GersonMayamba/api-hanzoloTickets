using Application.DTOs;
using Application.DTOs.Colaboradores;
using Application.DTOs.Ficheiros;
using Application.DTOs.Permissoes;
using AutoMapper;
using Domain.Entities;
using Domain.Identity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {


            CreateMap<NotaUtilizadorDTO, NotaUtilizador>().ReverseMap();
            CreateMap<GruposPermissoesDTO, GrupoPermissao>().ReverseMap();
            CreateMap<PermissoesUtilizadoresDTO, PermissaoUtilizador>().ReverseMap();
            CreateMap<PermissoesDTO, Permissao>().ReverseMap();
            CreateMap<GruposPermissoesDTO, GrupoPermissao>().ReverseMap();
            CreateMap<DominioDTO, Dominio>().ReverseMap();
            CreateMap<ProvinciaDTO, Provincia>().ReverseMap();
            CreateMap<MunicipioDTO, Municipio>().ReverseMap();
            CreateMap<UnidadeDTO, Unidade>().ReverseMap();
            CreateMap<UnidadeRequestDTO, Unidade>().ReverseMap();
            CreateMap<UnidadeUtilizadorDTO, UnidadeUtilizador>().ReverseMap();
            CreateMap<GrupoSexoDTO, GrupoSexo>().ReverseMap();
            CreateMap<DepartamentoDTO, Departamento>().ReverseMap();
            CreateMap<EspecialidadeMedicaDTO, EspecialidadeMedica>().ReverseMap();
            CreateMap<PrioridadeDTO, Prioridade>().ReverseMap();
            CreateMap<ProjectoManutencaoDTO, ProjectoManutencao>().ReverseMap();
            CreateMap<EstadoManutencaoDTO, EstadoManutencao>().ReverseMap();
            CreateMap<FamiliaDTO, Familia>().ReverseMap();
            CreateMap<OrigemManutencaoDTO, OrigemManutencao>().ReverseMap();
            CreateMap<ProjectoDTO, Projecto>().ReverseMap();
            CreateMap<TipoDominioDTO, TipoDominio>().ReverseMap();
            CreateMap<SubFamiliaDTO, SubFamilia>().ReverseMap();
            CreateMap<EquipamentoDTO, Equipamento>().ReverseMap();
            CreateMap<ManutencaoDTO, Manutencao>().ReverseMap();
            CreateMap<ManutencaoAddDTO, Manutencao>().ReverseMap();
            CreateMap<TipoUnidadeDTO, TipoUnidade>().ReverseMap();
            CreateMap<ProjectoManutencaoAddDTO, ProjectoManutencao>().ReverseMap();
            CreateMap<AlocacaoManutencaoDTO, AlocacaoManutencao>().ReverseMap();
            CreateMap<PrestadorUtilizadorDTO, PrestadorUtilizador>().ReverseMap();
            CreateMap<PrestadorDTO, Prestador>().ReverseMap();
            CreateMap<ZonaDTO, Zona>().ReverseMap();
            CreateMap<ManutencaoPreventivaAddDTO, Manutencao>().ReverseMap();
            CreateMap<ProjectoManutencaoPreventivaAddDTO, ProjectoManutencao>().ReverseMap();
            CreateMap<AlocacaoManutencaoAddDTO, AlocacaoManutencao>().ReverseMap();
            CreateMap<Comuna, ComunaDTO>().ReverseMap();
            CreateMap<TicketAtribuicaoDTO, TicketAtribuicao>().ReverseMap();
        }
    }
}
