using Moq;
using GTI.Dashboard.Repository;
using GTI.Dashboard.Services.CID;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GTI.Dashboard.Tests
{
    public class CIDServiceTests
    {
        private Mock<ICIDRepository> _mockRepository;
        private ICIDService _cidService;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<ICIDRepository>();
            _cidService = new CIDService(_mockRepository.Object);
        }

        [Test]
        public async Task Should_GetCIDWithSuccess()
        {
            #region Arrange
            var expectedResult = new List<CIDModel>()
            {
                new CIDModel { Mes = "Janeiro", N_pessoal = 1, Atestados = 2, Dias = "5", Diretoria = "RH", Unidade = "Central", Genero = "Feminino", Categoria = "A", Cid = "X1", DescricaoDetalhada = "Detalhe", DescricaoResumida = "Resumo", DiagnosticoAtestadoInicial = "Diagnóstico Inicial", CausaRaiz = "Causa Raiz", Outros = "N/A", Jornada = "Integral", Quantidade = 1 },
                new CIDModel { Mes = "Fevereiro", N_pessoal = 2, Atestados = 1, Dias = "3", Diretoria = "Financeiro", Unidade = "Sul", Genero = "Masculino", Categoria = "B", Cid = "Y2", DescricaoDetalhada = "Detalhe 2", DescricaoResumida = "Resumo 2", DiagnosticoAtestadoInicial = "Diagnóstico Inicial 2", CausaRaiz = "Causa Raiz 2", Outros = "N/A", Jornada = "Parcial", Quantidade = 2 }
            };

            _mockRepository.Setup(x => x.GetCID())
                           .ReturnsAsync(expectedResult);
            #endregion

            #region Act
            var result = await _cidService.GetCID();
            #endregion

            #region ClassicAssert
            ClassicAssert.AreEqual(expectedResult.Count, result.Count());
            ClassicAssert.AreEqual(expectedResult.First().Mes, result.First().Mes);
            #endregion
        }

        [Test]
        public async Task Should_GetCauseByHealthUnitWithSuccess()
        {
            #region Arrange
            var unit = "Central";
            var expectedResult = new List<CIDModel>()
            {
                new CIDModel { Mes = "Janeiro", Unidade = "Central", CausaRaiz = "Causa Raiz" }
            };

            _mockRepository.Setup(x => x.GetCauseByHealthUnit(unit))
                           .ReturnsAsync(expectedResult);
            #endregion

            #region Act
            var result = await _cidService.GetCauseByHealthUnit(unit);
            #endregion

            #region ClassicAssert
            ClassicAssert.AreEqual(expectedResult.Count, result.Count());
            ClassicAssert.AreEqual(expectedResult.First().Unidade, result.First().Unidade);
            ClassicAssert.AreEqual(expectedResult.First().CausaRaiz, result.First().CausaRaiz);
            #endregion
        }
    }
}
