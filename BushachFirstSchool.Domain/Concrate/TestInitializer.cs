using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BushachFirstSchool.Domain.Entity.Test;
using BushachFirstSchool.Domain.Entity;
using BushachFirstSchool.Domain.Abstract;

namespace BushachFirstSchool.Domain.Concrate
{
   public class TestInitializer
    {
            

       public TestInitializer(
                              Int32 countThesisInTestA = 4,
                              Int32 countThesisInTestD = 4,

                              Int32 countTestA = 4,
                              Int32 countTestB = 4,
                              Int32 countTestC = 4,
                              Int32 countTestD = 4,
                                
                              Int32 ratingTestA = 25,
                              Int32 ratingTestB = 25,
                              Int32 ratingTestC = 25,
                              Int32 ratingTestD = 25,
                              Int32 Duration = 20  )
       {
           

           _countThesisInTestB = countThesisInTestA;
           _countThesisInTestD = countThesisInTestD;

           _countTestA = countTestA;
           _countTestB = countTestB;
           _countTestC = countTestC;
           _countTestD = countTestD;

            _ratingTestA = ratingTestA;
            _ratingTestB = ratingTestB;
            _ratingTestC = ratingTestC;
            _ratingTestD = ratingTestD;
            _duration = Duration;

       }

       public TestCollection GenetrateTest(IEnumerable<Concept> concepts, IEnumerable<Thesis> thesises)
       {
           _conceptIterator = 0;
           
           return new TestCollection 
           {
               TestCollectionId = Guid.NewGuid(),
               TeststACol = generateTeastACollection(concepts.ToArray(),thesises),
               TeststBCol = generateTeastBCollection(concepts.ToArray(), thesises),
               TeststCCol = generateTeastCCollection(thesises),
               TeststDCol = generateTeastDCollection(concepts.ToArray()),

               TestARating = _ratingTestA,
               TestBRating = _ratingTestB,
               TestCRating = _ratingTestC,
               TestDRating = _ratingTestD,
               Duration = _duration
           };
       }
       public Decimal RequireTest(Guid testId, TestResult testresult, ISchoolRepositorycs repository, ref Int16 CountPastTest) 
       {
           var test = repository.Tests.FirstOrDefault(x => x.TestCollectionId ==testId );
           Decimal rating = 0;
           Decimal singlRatingA = test.TestARating / test.TeststACol.Count();
           Decimal singlRatingB = test.TestBRating / test.TeststBCol.Count();
           Decimal singlRatingC = test.TestCRating / test.TeststCCol.Count();
           Decimal singlRatingD = test.TestDRating / test.TeststDCol.Count();          

           var concepts = repository.SubjectsTheam
                                    .FirstOrDefault(x => x.TestCollection.TestCollectionId == test.TestCollectionId)
                                    .Concepts.ToList();
           Concept concept;
           
           //Test A
           foreach (var item  in testresult.testAColl )
           {
                concept = concepts.FirstOrDefault( x => x.ConceptId == item.conceptId);
                if(concept !=null)
                {
                    if(concept.Thesis.ThesisId == item.thesisId)
                    {
                       
                        if (item.answer == 1) {
                          rating=   rating + singlRatingA;
                          CountPastTest++;
                        }

                    }
                    else
                    {
                        if (item.answer == -1) {
                          rating=   rating + singlRatingA;
                          CountPastTest++;
                        }
                    }
                }
           }
           //Test B
           foreach (var item  in testresult.testBColl )
           {
                concept = concepts.FirstOrDefault( x => x.ConceptId == item.conceptId);
                if(concept !=null)
                {
                    
                    if (concept.Thesis.ThesisId == item.thesisId )
                    {
                        rating = rating + singlRatingB;
                        CountPastTest++;
                    }
                }
           }
           //Test C
           foreach (var item  in testresult.testCColl )
           {
               concept = concepts.FirstOrDefault(x => x.Thesis.ThesisId == item.conceptId);
               if (concept != null)
                {
                   
                   if (String.Compare(concept.body.Replace("\n", string.Empty).Trim(), item.answer.Replace("\n", string.Empty).Trim()) == 0)
                    {
                        rating = rating + singlRatingC;
                        CountPastTest++;
                    }
                }
           }
           //Test D
           Decimal singlRatingDpart;
          foreach (var item  in testresult.testDColl )
           {
             
               var singleAnswerD = item.SingleAnswerD.ToArray();
               singlRatingDpart = singlRatingD / singleAnswerD.Length;
               for (int i = 0; i < singleAnswerD.Length; i++)
                {
                    concept = concepts.FirstOrDefault(x => x.ConceptId == singleAnswerD[i].conceptId);
                    if(concept !=null)
                    {
                   
                        if (concept.Thesis.ThesisId == singleAnswerD[i].thesisId)
                        {
                            rating = rating + singlRatingDpart;
                            CountPastTest++;
                        }
                    }
                }
              
           }
           return rating;
       }
       private ICollection<TestA> generateTeastACollection(Concept[] concepts , IEnumerable<Thesis> thesises)
       {
           var list = new List<TestA>(_countTestA);
           for(int i = 0; i<_countTestA;i++)
           {
               if(_conceptIterator == concepts.Count())
               {
                   _conceptIterator = 0;
               }
               var testa = new TestA{
                   TestAId = Guid.NewGuid(),
                   concept = concepts[_conceptIterator],
                   thesis =thesises.OrderBy(elem => Guid.NewGuid()).FirstOrDefault()
               };
               list.Add(testa);
               _conceptIterator++;
           }
           return list;
       }
       private ICollection<TestB> generateTeastBCollection(Concept[] concepts, IEnumerable<Thesis> thesises)
       {
           var list = new List<TestB>(_countTestB);
           for (int i = 0; i < _countTestB; i++)
           {
               if (_conceptIterator == concepts.Count())
               {
                   _conceptIterator = 0;
               }
               var concept =concepts[_conceptIterator];
               var listThesis = new List<Thesis>(_countThesisInTestB);
               listThesis.Add(concept.Thesis);
               
               listThesis.AddRange(thesises.OrderBy(elem => Guid.NewGuid())
                                           .Where(x => x.ThesisId != concept.Thesis.ThesisId)
                                           .Take(3));
               var testB = new TestB
               {
                   TestBId = Guid.NewGuid(),
                   concept = concept,
                   thesises = listThesis
               };
               list.Add(testB);
               _conceptIterator++;
           }
           return list;
       }
       private ICollection<TestC> generateTeastCCollection( IEnumerable<Thesis> thesises)
       {
           var list = new List<TestC>(_countTestC);

           var teacherArr =  thesises.OrderBy(elem => Guid.NewGuid()).Take(_countTestC).ToArray();
           for (int i = 0; i < _countTestC; i++)
           {                              
                        
               var testC = new TestC
               {
                   TestCId = Guid.NewGuid(),
                   thesis = teacherArr[i]
               };
               list.Add(testC); 
             
           }
           return list;
       }
       private ICollection<TestD> generateTeastDCollection(Concept[] concepts)
       {
           var list = new List<TestD>(_countTestD);
           
           for (int i = 0; i < _countTestD; i++)
           {
               if (_conceptIterator == concepts.Count())
               {
                   _conceptIterator = 0;
               }
               if ((_conceptIterator + _countThesisInTestD) >  concepts.Count())
               {
                   _conceptIterator = concepts.Count() - _countThesisInTestD;
               }
               var conceptlist = concepts.Skip(_conceptIterator).Take(_countThesisInTestD).ToArray();
               var thesislist = new Thesis[_countThesisInTestD];
               for(int j = 0;j<conceptlist.Count();j++)
               {
                   thesislist[j] = conceptlist[j].Thesis;
               }
               TestD testD = new TestD
               {
                   TestDId = Guid.NewGuid(),
                   concept = conceptlist,
                   thesises = thesislist.OrderBy(x => Guid.NewGuid()).ToList()
               };
               list.Add(testD);
               _conceptIterator = _conceptIterator +4;

           }
           return list;
       }
       private Int32  _conceptIterator;
       
       private Int32 _countThesisInTestB;
       private Int32 _countThesisInTestD;

       private Int32 _countTestA;
       private Int32 _countTestB;
       private Int32 _countTestC;
       private Int32 _countTestD;

       private Int32 _ratingTestA;
       private Int32 _ratingTestB;
       private Int32 _ratingTestC;
       private Int32 _ratingTestD;
       private Int32 _duration;
    }

    
}
