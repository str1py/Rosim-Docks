using Microsoft.EntityFrameworkCore;
using RosreestDocks.Contexts;
using RosreestDocks.Interfaces;
using RosreestDocks.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace RosreestDocks.Helpers
{
    public class DictionaryCreator
    {
        private readonly DataBaseContext db;
        MainVars MainVars;
        public DictionaryCreator(DataBaseContext context)
        {
            db = context;
            MainVars = new(db);
        }

        private Dictionary<string,string> CreateAgencies(ICommonModel a, ICommonModel raspor)
        {
            Dictionary<string, string> ChangeDic = new();
            if (raspor.WhoApplied == 0)//0 принимающая сторона - 1 передающая сторона
            {
                if (a.TransferAgency.NameRodPad != null)
                {
                    a.WhoAppliedAgency = (new WhoAppliedModel
                    {
                        AcronymTvorPad = a.TransferAgency.Acronym.AcronymTvorPad,
                        AcronymRodPad = a.TransferAgency.Acronym.AcronymRodPad,
                        Name = "",
                        NameDatPad = a.TransferAgency.NameDatPad,
                        NameRodPad = a.TransferAgency.NameRodPad,
                        NameTvorPad = a.TransferAgency.NameTvorPad,
                        NameImPad = a.TransferAgency.NameImPad,
                        AddInfo = a.TransferAgency.AddInfo,
                        Date = a.TransferAppeal?.Date ?? "null",
                        Number = a.TransferAppeal?.Number ?? "null"
                    });
                }
                else
                {
                    a.WhoAppliedAgency = (new WhoAppliedModel
                    {
                        AcronymTvorPad = a.TransferAgency.Acronym.AcronymTvorPad,
                        AcronymRodPad = a.TransferAgency.Acronym.AcronymRodPad,
                        Name = "«" + a.TransferAgency.Name + "»",
                        NameDatPad = "",
                        NameRodPad = "",
                        NameTvorPad = "",
                        NameImPad = "",
                        AddInfo = a.TransferAgency.AddInfo,
                        Date = a.TransferAppeal?.Date ?? "null",
                        Number = a.TransferAppeal?.Number ?? "null"
                    });
                }

                if (a.RecipientAgency.NameRodPad != null)
                {
                    a.WhoAgreeModelAgency = (new WhoAgreeModel
                    {
                        AcronymTvorPad = a.RecipientAgency.Acronym.AcronymTvorPad,
                        AcronymRodPad = a.RecipientAgency.Acronym.AcronymRodPad,
                        Name = "",
                        NameDatPad = a.RecipientAgency.NameDatPad,
                        NameRodPad = a.RecipientAgency.NameRodPad,
                        NameTvorPad = a.RecipientAgency.NameTvorPad,
                        NameImPad = a.RecipientAgency.NameImPad,
                        AddInfo = a.RecipientAgency.AddInfo,
                        Date = a.RecipientAppeal?.Date ?? "null",
                        Number = a.RecipientAppeal?.Number ?? "null"
                    });
                }
                else
                {
                    a.WhoAgreeModelAgency = (new WhoAgreeModel
                    {
                        AcronymRodPad = a.RecipientAgency.Acronym.AcronymRodPad,
                        AcronymTvorPad = a.RecipientAgency.Acronym.AcronymTvorPad,
                        Name = "«" + a.RecipientAgency.Name + "»",
                        NameDatPad = "",
                        NameRodPad = "",
                        NameTvorPad = "",
                        NameImPad = "",
                        AddInfo = a.RecipientAgency.AddInfo,
                        Date = a.RecipientAppeal?.Date ?? "null",
                        Number = a.RecipientAppeal?.Number ?? "null"
                    });
                }

            }
            else
            {
                if (a.RecipientAgency.NameRodPad != null)
                {
                    a.WhoAppliedAgency = (new WhoAppliedModel
                    {
                        AcronymRodPad = a.RecipientAgency.Acronym.AcronymRodPad,
                        AcronymTvorPad = a.RecipientAgency.Acronym.AcronymTvorPad,
                        Name = "",
                        NameDatPad = a.RecipientAgency.NameDatPad,
                        NameRodPad = a.RecipientAgency.NameRodPad,
                        NameTvorPad = a.RecipientAgency.NameTvorPad,
                        AddInfo = a.RecipientAgency.AddInfo,
                        Date = a.RecipientAppeal?.Date ?? "null",
                        Number = a.RecipientAppeal?.Number ?? "null"
                    });

                }
                else
                {
                    a.WhoAppliedAgency = (new WhoAppliedModel
                    {
                        AcronymRodPad = a.RecipientAgency.Acronym.AcronymRodPad,
                        AcronymTvorPad = a.RecipientAgency.Acronym.AcronymTvorPad,
                        Name = "«" + a.RecipientAgency.Name + "»",
                        NameDatPad = "",
                        NameRodPad = "",
                        NameTvorPad = "",
                        AddInfo = a.RecipientAgency.AddInfo,
                        Date = a.RecipientAppeal?.Date ?? "null",
                        Number = a.RecipientAppeal?.Number ?? "null"
                    });
                }

                if (a.TransferAgency.NameRodPad != null)
                {
                    a.WhoAgreeModelAgency = (new WhoAgreeModel
                    {
                        AcronymRodPad = a.TransferAgency.Acronym.AcronymRodPad,
                        AcronymTvorPad = a.TransferAgency.Acronym.AcronymTvorPad,
                        Name = "",
                        NameDatPad = a.TransferAgency.NameDatPad,
                        NameRodPad = a.TransferAgency.NameRodPad,
                        NameTvorPad = a.TransferAgency.NameTvorPad,
                        AddInfo = a.TransferAgency.AddInfo,
                        Date = a.TransferAppeal?.Date ?? "null",
                        Number = a.TransferAppeal?.Number ?? "null"
                    });
                }
                else
                {
                    a.WhoAgreeModelAgency = (new WhoAgreeModel
                    {
                        AcronymRodPad = a.TransferAgency.Acronym.AcronymRodPad,
                        AcronymTvorPad = a.TransferAgency.Acronym.AcronymTvorPad,
                        Name = "«" + a.TransferAgency.Name + "»",
                        NameDatPad = "",
                        NameRodPad = "",
                        NameTvorPad = "",
                        AddInfo = a.TransferAgency.AddInfo,
                        Date = a.TransferAppeal?.Date ?? "null",
                        Number = a.TransferAppeal?.Number ?? "null"
                    });
                }
            }

            ChangeDic.Add("WhoAgreeImPad", a.WhoAgreeModelAgency.NameImPad);
            ChangeDic.Add("WhoAgreeRodPad", a.WhoAgreeModelAgency.NameRodPad);
            ChangeDic.Add("WhoAgreeDatPad", a.WhoAgreeModelAgency.NameDatPad);
            ChangeDic.Add("WhoAgreeTvorPad", a.WhoAgreeModelAgency.NameTvorPad);
            ChangeDic.Add("WhoAgreeName", a.WhoAgreeModelAgency.Name);

            ChangeDic.Add("WhoAppliedImPadPad", a.WhoAppliedAgency.NameImPad);
            ChangeDic.Add("WhoAppliedRodPad", a.WhoAppliedAgency.NameRodPad);
            ChangeDic.Add("WhoApplieDatPad", a.WhoAppliedAgency.NameDatPad);
            ChangeDic.Add("WhoAppliedTvorPad", a.WhoAppliedAgency.NameTvorPad);
            ChangeDic.Add("WhoAppliedName", a.WhoAppliedAgency.Name);

            if (a.RecipientAgency.NameRodPad != null)
            {
                ChangeDic.Add("RecipientAgencyImPad", a.RecipientAgency.NameImPad);
                ChangeDic.Add("RecipientAgencyRodPad", a.RecipientAgency.NameRodPad);
                ChangeDic.Add("RecipientAgencyDatPad", a.RecipientAgency.NameDatPad);
                ChangeDic.Add("RecipientAgencyTvorPad", a.RecipientAgency.NameTvorPad);
                ChangeDic.Add("RecipientAgencyName", "");
            }
            else
            {
                ChangeDic.Add("RecipientAgencyImPad", "");
                ChangeDic.Add("RecipientAgencyRodPad", "");
                ChangeDic.Add("RecipientAgencyDatPad", "");
                ChangeDic.Add("RecipientAgencyTvorPad", "");
                ChangeDic.Add("RecipientAgencyName", "«" + a.RecipientAgency.Name + "»");
            }

            if (a.TransferAgency.NameRodPad != null)
            {
                ChangeDic.Add("TransferAgencyImPad", a.TransferAgency.NameImPad);
                ChangeDic.Add("TransferAgencyRodPad", a.TransferAgency.NameRodPad);
                ChangeDic.Add("TransferAgencyDatPad", a.TransferAgency.NameDatPad);
                ChangeDic.Add("TransferAgencyTvorPad", a.TransferAgency.NameTvorPad);
                ChangeDic.Add("TransferAgencyName", "");
            }
            else
            {
                ChangeDic.Add("TransferAgencyImPad", "");
                ChangeDic.Add("TransferAgencyRodPad", "");
                ChangeDic.Add("TransferAgencyDatPad", "");
                ChangeDic.Add("TransferAgencyTvorPad", "");
                ChangeDic.Add("TransferAgencyName", "«" + a.TransferAgency.Name + "»");
            }


            ChangeDic.Add("TypeOfPropertyRodPad", a.TypeOfProperty.PropertyRodPad);
            ChangeDic.Add("TypeOfPropertyImPad", a.TypeOfProperty.Name);
            ChangeDic.Add("Articles", a.Articles?.Name ?? "null");
            ChangeDic.Add("ManageRightsRodPadTo", a.ManageRightsTo.RightsRodPad);
            ChangeDic.Add("ManageRightsRodPadFrom", a.ManageRightsFrom.RightsRodPad);
            ChangeDic.Add("ManageRightsImPadTo", a.ManageRightsTo.Name);
            ChangeDic.Add("ManageRightsImPadFrom", a.ManageRightsFrom.Name);


            ChangeDic.Add("RecipientAgencyAcromym", a.RecipientAgency.Acronym.AcronymImPad);
            ChangeDic.Add("RAATvorPad", a.RecipientAgency.Acronym.AcronymTvorPad);
            ChangeDic.Add("RAADatPad", a.RecipientAgency.Acronym.AcronymDatPad);
            ChangeDic.Add("RecipientAgencyAdress", a.RecipientAgency.Adress);
            ChangeDic.Add("RecipientAgencyCityAndZip", a.RecipientAgency.CityAndZip);
            ChangeDic.Add("RecipientAgencyINN", a.RecipientAgency.AgencyINN);
            ChangeDic.Add("RecipientAgencyAddInfo", a.RecipientAgency.AddInfo);

            ChangeDic.Add("TransferAgencyAcromym", a.TransferAgency.Acronym.AcronymImPad);
            ChangeDic.Add("TAADatPad", a.TransferAgency.Acronym.AcronymDatPad);
            ChangeDic.Add("TAARodPad", a.TransferAgency.Acronym.AcronymRodPad);
            ChangeDic.Add("TransferAgencyAdress", a.TransferAgency.Adress);
            ChangeDic.Add("TransferAgencyCityAndZip", a.TransferAgency.CityAndZip);
            ChangeDic.Add("TransferAgencyINN", a.TransferAgency.AgencyINN);
            ChangeDic.Add("TransferAgencyAddInfo", a.TransferAgency.AddInfo);

            ChangeDic.Add("WhoAppliedAcronymTvorPad", a.WhoAppliedAgency.AcronymTvorPad);
            ChangeDic.Add("WhoAppliedAcronymRodPad", a.WhoAppliedAgency.AcronymRodPad);
            ChangeDic.Add("WhoAppliedDate", a.WhoAppliedAgency.Date);
            ChangeDic.Add("WhoAppliedNumber", a.WhoAppliedAgency.Number);
            ChangeDic.Add("WhoAppliedAddInfo", a.WhoAppliedAgency.AddInfo);

            ChangeDic.Add("WhoAgreeAcronymTvorPad", a.WhoAgreeModelAgency.AcronymTvorPad);
            ChangeDic.Add("WhoAgreeAcronymRodPad", a.WhoAgreeModelAgency.AcronymRodPad);
            ChangeDic.Add("WhoAgreeDate", a.WhoAgreeModelAgency.Date);
            ChangeDic.Add("WhoAgreeNumber", a.WhoAgreeModelAgency.Number);
            ChangeDic.Add("WhoAgreeAddInfo", a.WhoAgreeModelAgency.AddInfo);

            ChangeDic.Add("BLTraAgency", a.TransferAgency.Acronym.AcronymImPad?.FirstCharToUpper() ?? "");
            ChangeDic.Add("BLRecAcromym", a.RecipientAgency.Acronym.AcronymImPad?.FirstCharToUpper() ?? "");
            ChangeDic.Add("BLrecagacDatPad", a.RecipientAgency.Acronym.AcronymDatPad?.FirstCharToUpper() ?? "");
            ChangeDic.Add("BLtranagacDatPad", a.TransferAgency.Acronym.AcronymDatPad?.FirstCharToUpper() ?? "");

            return ChangeDic;
        }

        public Dictionary<string, string> CrateZaprosDictionary(ZaprosCA zapros)
        {
            var a = zapros;
            a.RecipientAgency = db.Agency.Where(x => x.Id == zapros.RecipientAgency.Id).Include(x=>x.Acronym).FirstOrDefault();
            a.TransferAgency = db.Agency.Where(x => x.Id == zapros.TransferAgency.Id).Include(x => x.Acronym).FirstOrDefault();
            a.ManageRightsFrom = db.ManageRights.Where(x => x.Id == zapros.ManageRightsFrom.Id).FirstOrDefault();
            a.ManageRightsTo = db.ManageRights.Where(x => x.Id == zapros.ManageRightsTo.Id).FirstOrDefault();
            a.TypeOfProperty = db.TypeOfPropertyModels.Where(x => x.Id == zapros.TypeOfProperty.Id).FirstOrDefault();
            var ChangeDic = CreateAgencies(a, zapros);

            if (String.IsNullOrEmpty(a.AdditionalInfo))
                ChangeDic.Add("AdditionalInfo", "");
            else
                ChangeDic.Add("AdditionalInfo", $", {a.AdditionalInfo},");

            if (a.HowMuch == 0)
            {
                ChangeDic.Add("Objects ", "объекта");
                ChangeDic.Add("Pins", "закрепленного");
            }
            else if (a.HowMuch == 1)
            {
                ChangeDic.Add("Objects ", "объектов");
                ChangeDic.Add("Pins ", "закрепленных");
            }

            ChangeDic.Add("PropertyDiscription", $"{a.PropertyDiscription}");


            return ChangeDic;
        }
     
        public Dictionary<string, string> CreateRasporVyaDictionary(RasporVyaModel raspor)
        {
            var a = raspor;
            a.Articles = db.Articles.Where(x => x.Id == Convert.ToInt32(raspor.Articles)).SingleOrDefault().Name;
            a.ManageRightsFrom = db.ManageRights.Where(x => x.Id == raspor.ManageRightsFrom.Id).FirstOrDefault();
            a.ManageRightsTo = db.ManageRights.Where(x => x.Id == raspor.ManageRightsTo.Id).FirstOrDefault();
            a.TypeOfProperty = db.TypeOfPropertyModels.Where(x => x.Id == raspor.TypeOfProperty.Id).FirstOrDefault();
            a.RecipientAgencyAcromym = db.Acronyms.Where(x => x.Id == raspor.RecipientAgencyAcromym.Id).FirstOrDefault();
            a.TransferAgencyAcromym = db.Acronyms.Where(x => x.Id == raspor.TransferAgencyAcromym.Id).FirstOrDefault();
            Dictionary<string, string> ChangeDic = new();

            if (raspor.WhoApplied == 0)//0 принимающая сторона - 1 передающая сторона
            {
                if (a.TransferAgencyCustomName == true)
                {
                    a.WhoAppliedAgency = (new WhoAppliedModel
                    {
                        AcronymTvorPad = a.TransferAgencyAcromym.AcronymTvorPad,
                        AcronymRodPad = a.TransferAgencyAcromym.AcronymRodPad,
                        Name = "",
                        NameDatPad = a.TransferAgency.NameDatPad,
                        NameRodPad = a.TransferAgency.NameRodPad,
                        NameTvorPad = a.TransferAgency.NameTvorPad,
                        NameImPad = a.TransferAgency.NameImPad,
                        AddInfo = a.TransferAgency.AddInfo,
                        Date = a.TransferAgency.AppealDate,
                        Number = a.TransferAgency.AppealNumber
                    });
                }
                else
                {
                    a.WhoAppliedAgency = (new WhoAppliedModel
                    {
                        AcronymTvorPad = a.TransferAgencyAcromym.AcronymTvorPad,
                        AcronymRodPad = a.TransferAgencyAcromym.AcronymRodPad,
                        Name = "«" + a.TransferAgency.Name + "»",
                        NameDatPad = "",
                        NameRodPad = "",
                        NameTvorPad = "",
                        NameImPad = "",
                        AddInfo = a.TransferAgency.AddInfo,
                        Date = a.TransferAgency.AppealDate,
                        Number = a.TransferAgency.AppealNumber
                    });
                }

                if (a.RecipientAgencyCustomName == true)
                {
                    a.WhoAgreeModelAgency = (new WhoAgreeModel
                    {
                        AcronymRodPad = a.RecipientAgencyAcromym.AcronymRodPad,
                        Name = "",
                        NameDatPad = a.RecipientAgency.NameDatPad,
                        NameRodPad = a.RecipientAgency.NameRodPad,
                        NameTvorPad = a.RecipientAgency.NameTvorPad,
                        NameImPad = a.RecipientAgency.NameImPad,
                        AddInfo = a.RecipientAgency.AddInfo,
                        Date = a.RecipientAgency.AppealDate,
                        Number = a.RecipientAgency.AppealNumber
                    });
                }
                else
                {
                    a.WhoAgreeModelAgency = (new WhoAgreeModel
                    {
                        AcronymRodPad = a.RecipientAgencyAcromym.AcronymRodPad,
                        Name = "«" + a.RecipientAgency.Name + "»",
                        NameDatPad = "",
                        NameRodPad = "",
                        NameTvorPad = "",
                        NameImPad = "",
                        AddInfo = a.RecipientAgency.AddInfo,
                        Date = a.RecipientAgency.AppealDate,
                        Number = a.RecipientAgency.AppealNumber
                    });
                }

            }
            else
            {
                if (a.RecipientAgencyCustomName == true)
                {
                    a.WhoAppliedAgency = (new WhoAppliedModel
                    {
                        AcronymRodPad = a.RecipientAgencyAcromym.AcronymRodPad,
                        Name = "",
                        NameDatPad = a.RecipientAgency.NameDatPad,
                        NameRodPad = a.RecipientAgency.NameRodPad,
                        NameTvorPad = a.RecipientAgency.NameTvorPad,
                        AddInfo = a.RecipientAgency.AddInfo,
                        Date = a.RecipientAgency.AppealDate,
                        Number = a.RecipientAgency.AppealNumber
                    });

                }
                else
                {
                    a.WhoAppliedAgency = (new WhoAppliedModel
                    {
                        AcronymRodPad = a.RecipientAgencyAcromym.AcronymRodPad,
                        Name = a.RecipientAgency.Name,
                        NameDatPad = "",
                        NameRodPad = "",
                        NameTvorPad = "",
                        AddInfo = a.RecipientAgency.AddInfo,
                        Date = a.RecipientAgency.AppealDate,
                        Number = a.RecipientAgency.AppealNumber
                    });
                }

                if (a.TransferAgencyCustomName == true)
                {
                    a.WhoAgreeModelAgency = (new WhoAgreeModel
                    {
                        AcronymRodPad = a.TransferAgencyAcromym.AcronymRodPad,
                        Name = "",
                        NameDatPad = a.TransferAgency.NameDatPad,
                        NameRodPad = a.TransferAgency.NameRodPad,
                        NameTvorPad = a.TransferAgency.NameTvorPad,
                        AddInfo = a.TransferAgency.AddInfo,
                        Date = a.TransferAgency.AppealDate,
                        Number = a.TransferAgency.AppealNumber
                    });
                }
                else
                {
                    a.WhoAgreeModelAgency = (new WhoAgreeModel
                    {
                        AcronymRodPad = a.TransferAgencyAcromym.AcronymRodPad,
                        Name = a.TransferAgency.Name,
                        NameDatPad = "",
                        NameRodPad = "",
                        NameTvorPad = "",
                        AddInfo = a.TransferAgency.AddInfo,
                        Date = a.TransferAgency.AppealDate,
                        Number = a.TransferAgency.AppealNumber
                    });
                }
            }

            ChangeDic.Add("WhoAgreeImPad", a.WhoAgreeModelAgency.NameImPad);
            ChangeDic.Add("WhoAgreeRodPad", a.WhoAgreeModelAgency.NameRodPad);
            ChangeDic.Add("WhoAgreeDatPad", a.WhoAgreeModelAgency.NameDatPad);
            ChangeDic.Add("WhoAgreeTvorPad", a.WhoAgreeModelAgency.NameTvorPad);
            ChangeDic.Add("WhoAgreeName", a.WhoAgreeModelAgency.Name);

            ChangeDic.Add("WhoAppliedImPadPad", a.WhoAppliedAgency.NameImPad);
            ChangeDic.Add("WhoAppliedRodPad", a.WhoAppliedAgency.NameRodPad);
            ChangeDic.Add("WhoApplieDatPad", a.WhoAppliedAgency.NameDatPad);
            ChangeDic.Add("WhoAppliedTvorPad", a.WhoAppliedAgency.NameTvorPad);
            ChangeDic.Add("WhoAppliedName", a.WhoAppliedAgency.Name);

            if (a.RecipientAgencyCustomName == true)
            {
                ChangeDic.Add("RecipientAgencyImPad", a.RecipientAgency.NameImPad);
                ChangeDic.Add("RecipientAgencyRodPad", a.RecipientAgency.NameRodPad);
                ChangeDic.Add("RecipientAgencyDatPad", a.RecipientAgency.NameDatPad);
                ChangeDic.Add("RecipientAgencyTvorPad", a.RecipientAgency.NameTvorPad);
                ChangeDic.Add("RecipientAgencyName", "");
            }
            else
            {
                ChangeDic.Add("RecipientAgencyImPad", "");
                ChangeDic.Add("RecipientAgencyRodPad", "");
                ChangeDic.Add("RecipientAgencyDatPad", "");
                ChangeDic.Add("RecipientAgencyTvorPad", "");
                ChangeDic.Add("RecipientAgencyName", "«" + a.RecipientAgency.Name + "»");
            }

            if (a.TransferAgencyCustomName == true)
            {
                ChangeDic.Add("TransferAgencyImPad", a.TransferAgency.NameImPad);
                ChangeDic.Add("TransferAgencyRodPad", a.TransferAgency.NameRodPad);
                ChangeDic.Add("TransferAgencyDatPad", a.TransferAgency.NameDatPad);
                ChangeDic.Add("TransferAgencyTvorPad", a.TransferAgency.NameTvorPad);
                ChangeDic.Add("TransferAgencyName", "");
            }
            else
            {
                ChangeDic.Add("TransferAgencyImPad", "");
                ChangeDic.Add("TransferAgencyRodPad", "");
                ChangeDic.Add("TransferAgencyDatPad", "");
                ChangeDic.Add("TransferAgencyTvorPad", "");
                ChangeDic.Add("TransferAgencyName", "«" + a.TransferAgency.Name + "»");
            }


            ChangeDic.Add("TypeOfPropertyRodPad", a.TypeOfProperty.PropertyRodPad);
            ChangeDic.Add("TypeOfPropertyImPad", a.TypeOfProperty.Name);
            ChangeDic.Add("Articles", a.Articles);
            ChangeDic.Add("ManageRightsRodPadTo", a.ManageRightsTo.RightsRodPad);
            ChangeDic.Add("ManageRightsRodPadFrom", a.ManageRightsFrom.RightsRodPad);

            ChangeDic.Add("RecipientAgencyAcromym", a.RecipientAgencyAcromym.AcronymImPad);
            ChangeDic.Add("RAATvorPad", a.RecipientAgencyAcromym.AcronymTvorPad);
            ChangeDic.Add("RAADatPad", a.RecipientAgencyAcromym.AcronymDatPad);

            ChangeDic.Add("RecipientAgencyAdress", a.RecipientAgency.Adress);
            ChangeDic.Add("RecipientAgencyCityAndZip", a.RecipientAgency.CityAndZip);
            ChangeDic.Add("RecipientAgencyINN", a.RecipientAgency.AgencyINN);
            ChangeDic.Add("RecipientAgencyAddInfo", a.RecipientAgency.AddInfo);

            ChangeDic.Add("TransferAgencyAcromym", a.TransferAgencyAcromym.AcronymImPad);
            ChangeDic.Add("TAADatPad", a.TransferAgencyAcromym.AcronymDatPad);
            ChangeDic.Add("TAARodPad", a.TransferAgencyAcromym.AcronymRodPad);

            ChangeDic.Add("TransferAgencyAdress", a.TransferAgency.Adress);
            ChangeDic.Add("TransferAgencyCityAndZip", a.TransferAgency.CityAndZip);
            ChangeDic.Add("TransferAgencyINN", a.TransferAgency.AgencyINN);
            ChangeDic.Add("TransferAgencyAddInfo", a.TransferAgency.AddInfo);

            ChangeDic.Add("WhoAppliedAcronymTvorPad", a.WhoAppliedAgency.AcronymTvorPad);
            ChangeDic.Add("WhoAppliedAcronymRodPad", a.WhoAppliedAgency.AcronymRodPad);

            ChangeDic.Add("WhoAppliedDate", a.WhoAppliedAgency.Date);
            ChangeDic.Add("WhoAppliedNumber", a.WhoAppliedAgency.Number);
            ChangeDic.Add("WhoAppliedAddInfo", a.WhoAppliedAgency.AddInfo);

            ChangeDic.Add("WhoAgreeAcronymRodPad", a.WhoAgreeModelAgency.AcronymRodPad);

            ChangeDic.Add("WhoAgreeDate", a.WhoAgreeModelAgency.Date);
            ChangeDic.Add("WhoAgreeNumber", a.WhoAgreeModelAgency.Number);
            ChangeDic.Add("WhoAgreeAddInfo", a.WhoAgreeModelAgency.AddInfo);

            ChangeDic.Add("BLTraAgency", a.TransferAgencyAcromym.AcronymImPad?.FirstCharToUpper() ?? "");
            ChangeDic.Add("BLRecAcromym", a.RecipientAgencyAcromym.AcronymImPad?.FirstCharToUpper() ?? "");
            ChangeDic.Add("BLrecagacDatPad", a.RecipientAgencyAcromym.AcronymDatPad?.FirstCharToUpper() ?? "");
            ChangeDic.Add("BLtranagacDatPad", a.TransferAgencyAcromym.AcronymDatPad?.FirstCharToUpper() ?? "");



            if (!String.IsNullOrEmpty(raspor.FirstFoiv.Number))
            {
                var f = db.Foiv.Where(x => x.Name == a.FirstFoiv.Name).FirstOrDefault();
                ChangeDic.Add("FirstFoivString", ", по согласованию c " + (f?.FoivTvorPad ?? a.FirstFoiv.Name) + " от " + a.FirstFoiv.Date + " г. № " + a.FirstFoiv.Number);
            }
            else
                ChangeDic.Add("FirstFoivString", "");

            if (!String.IsNullOrEmpty(raspor.SecondFoiv.Number))
            {
                var f = db.Foiv.Where(x => x.Name == a.SecondFoiv.Name).FirstOrDefault();
                ChangeDic.Add("SecondFoivString", ", " + f?.FoivTvorPad ?? a.SecondFoiv.Name + " от " + a.SecondFoiv.Date + "г. № " + a.SecondFoiv.Number);
            }
            else
                ChangeDic.Add("SecondFoivString", "");

            if (a.IsRosim == true)
            {
                ChangeDic.Add("RosImRaspor", "во исполнении поручений Федерального агентства по управлению государственным имуществом от 06 июня 2017 г. № ДП-08/22081 и от " + a.RosimDate + " г. № " + a.RosimNumber);
                ChangeDic.Add("RosImSoprovod", "Во исполнение поручения Федерального агентства по управлению государственным имуществом от" + a.RosimDate + " г. № "+ a.RosimNumber);
                ChangeDic.Add("SopPrilRosIm", "1 экз. Распоряжения в электронном виде в третий адрес");
                ChangeDic.Add("RosImName", "Росимущество");
            }
            else
            {
                ChangeDic.Add("RosImRaspor", "во исполнении поручения Федерального агентства по управлению государственным имуществом от 06 июня 2017 г. № ДП-08/22081");
                ChangeDic.Add("RosImSoprovod", "");
                ChangeDic.Add("SopPrilRosIm", "1 экз. Распоряжения в электронном виде в третий адрес.");             
                ChangeDic.Add("RosImName", "");
            }

            if (a.BuildingsString)
                ChangeDic.Add("BuildingsString", "-обеспечить оформление земельно-правовых отношений.");
            else ChangeDic.Add("BuildingsString", "");
            return ChangeDic;
        }


        public Dictionary<string, string> CreateRasporVyaByRequest(RequestModel raspor)
        {
            var a = raspor;
            a.Articles = db.Articles.Where(x => x.Id == raspor.Articles.Id).SingleOrDefault();
            a.ManageRightsFrom = db.ManageRights.Where(x => x.Id == raspor.ManageRightsFrom.Id).FirstOrDefault();
            a.ManageRightsTo = db.ManageRights.Where(x => x.Id == raspor.ManageRightsTo.Id).FirstOrDefault();
            a.TypeOfProperty = db.TypeOfPropertyModels.Where(x => x.Id == raspor.TypeOfProperty.Id).FirstOrDefault();
            a.RecipientAgency = db.Agency.Where(x => x.Id == raspor.RecipientAgency.Id).Include(x => x.Acronym).FirstOrDefault();
            a.TransferAgency = db.Agency.Where(x => x.Id == raspor.TransferAgency.Id).Include(x => x.Acronym).FirstOrDefault();
            var ChangeDic = CreateAgencies(a, raspor);



            if (!String.IsNullOrEmpty(a.FirstFoivAppeal.Number))
            {
                var f = db.Foiv.Where(x => x.Name == a.FirstFoiv.Name).FirstOrDefault();
                ChangeDic.Add("FirstFoivString", ", по согласованию c " + (f?.FoivTvorPad ?? a.FirstFoiv.Name) + " от " + a.FirstFoivAppeal.Date + " г. № " + a.FirstFoivAppeal.Number);
            }
            else
                ChangeDic.Add("FirstFoivString", "");

            if (!String.IsNullOrEmpty(a.SecondFoivAppeal.Number))
            {
                var f = db.Foiv.Where(x => x.Name == a.SecondFoiv.Name).FirstOrDefault();
                ChangeDic.Add("SecondFoivString", "и " + (f?.FoivTvorPad ?? a.SecondFoiv.Name) + " от " + a.SecondFoivAppeal.Date + "г. № " + a.SecondFoivAppeal.Number);
            }
            else
                ChangeDic.Add("SecondFoivString", "");

            if (a.IsRosim == true)
            {
                if (raspor.WhatAnnex == 0 || raspor.WhatAnnex == 1)
                    ChangeDic.Add("RosImRaspor", "во исполнение поручений Федерального агентства по управлению государственным имуществом от 06 июня 2017 г. № ДП-08/22081 и от " + a.RosimAppeal.Date + " г. № " + a.RosimAppeal.Number);
                else ChangeDic.Add("RosImRaspor", "во исполнение поручения Федерального агентства по управлению государственным имуществом от " + a.RosimAppeal.Date + " г. № " + a.RosimAppeal.Number);
                
                ChangeDic.Add("RosImSoprovod", "Во исполнение поручения Федерального агентства по управлению государственным имуществом от" + a.RosimAppeal.Date + " г. № " + a.RosimAppeal.Number);
                ChangeDic.Add("SopPrilRosIm", "1 экз. Распоряжения в электронном виде в третий адрес.");
                ChangeDic.Add("RosImName", "Росимущество");
            }
            else
            {
                if(raspor.WhatAnnex == 0 || raspor.WhatAnnex == 1)
                    ChangeDic.Add("RosImRaspor", "во исполнении поручения Федерального агентства по управлению государственным имуществом от 06 июня 2017 г. № ДП-08/22081");
                else ChangeDic.Add("RosImRaspor", "");

                ChangeDic.Add("RosImSoprovod", "");
                ChangeDic.Add("SopPrilRosIm", "1 экз. Распоряжения в электронном виде в третий адрес.");
                ChangeDic.Add("RosImName", "");
            }

            if (a.BuildingsString)
                ChangeDic.Add("BuildingsString", "- обеспечить оформление земельно-правовых отношений.");
            else ChangeDic.Add("BuildingsString", "");
            return ChangeDic;
        }
        public Dictionary<string,string> CreateRunner(RequestModel raspor)
        {
            var a = raspor;
            a.ManageRightsFrom = db.ManageRights.Where(x => x.Id == raspor.ManageRightsFrom.Id).FirstOrDefault();
            a.ManageRightsTo = db.ManageRights.Where(x => x.Id == raspor.ManageRightsTo.Id).FirstOrDefault();
            a.TypeOfProperty = db.TypeOfPropertyModels.Where(x => x.Id == raspor.TypeOfProperty.Id).FirstOrDefault();
            a.RecipientAgency = db.Agency.Where(x => x.Id == raspor.RecipientAgency.Id).Include(x => x.Acronym).FirstOrDefault();
            a.TransferAgency = db.Agency.Where(x => x.Id == raspor.TransferAgency.Id).Include(x => x.Acronym).FirstOrDefault();
            var ChangeDic = CreateAgencies(a, raspor);

            ChangeDic.Add("DockNumber", a.DocName);
            ChangeDic.Add("DockDate", a.DocDate.ToShortDateString());
            ChangeDic.Add("DockExpire", a.ExpireDate.ToShortDateString());
            ChangeDic.Add("RecipientAgencyAppealDate", a.RecipientAppeal.Date);
            ChangeDic.Add("RecipientAgencyNumber", a.RecipientAppeal.Number);
            ChangeDic.Add("TransferAgencyAppealDate", a.TransferAppeal.Date);
            ChangeDic.Add("TransferAgencyNumber", a.TransferAppeal.Number);


            if (String.IsNullOrEmpty(a.RosimAppeal.Date))
                ChangeDic.Add("RosImAppeal", "не требуется");
            else
                ChangeDic.Add("RosImAppeal", "от " + a.RosimAppeal.Date + " г. № " + a.RosimAppeal.Number);

            if (!String.IsNullOrEmpty(a.FirstFoivAppeal.Number))
            {
                var f = db.Foiv.Where(x => x.Name == a.FirstFoiv.Name).FirstOrDefault();
                ChangeDic.Add("FirstFoivString", a.FirstFoiv.Name + " от " + a.FirstFoivAppeal.Date + " г. №" + a.FirstFoivAppeal.Number);
            }
            else
                ChangeDic.Add("FirstFoivString", "");

            if (!String.IsNullOrEmpty(a.SecondFoivAppeal.Number))
            {
                var f = db.Foiv.Where(x => x.Name == a.SecondFoiv.Name).FirstOrDefault();
                ChangeDic.Add("SecondFoivString", a.SecondFoiv.Name + " от " + a.SecondFoivAppeal.Date + "г. №" + a.SecondFoivAppeal.Number);
            }
            else
                ChangeDic.Add("SecondFoivString", "");

            ChangeDic.Add("TransferRegular", a.TransferAgency.RegulationName);
            ChangeDic.Add("ResipientRegular", a.RecipientAgency.RegulationName);

            //a.TransferAgency.Director = db.Director.Where(x => x.Id == raspor.TransferAgency.Director.Id).SingleOrDefault();
            //a.RecipientAgency.Director = db.Director.Where(x => x.Id == raspor.RecipientAgency.Director.Id).SingleOrDefault();


            //if (a.TransferAgency.Director != null)
            //    ChangeDic.Add("TransferDirector", a.TransferAgency.Director.Name + " - егрюл");

            //if (a.RecipientAgency.Director != null)
            //    ChangeDic.Add("RecipientDirector", a.RecipientAgency.Director.Name + " - егрюл");

            ChangeDic.Add("PropertyDiscription", a.PropertyDiscription);

            return ChangeDic;
        }
        public Dictionary<string, string> CreateZapros(RequestModel raspor)
        {
            var a = raspor;
            a.ManageRightsFrom = db.ManageRights.Where(x => x.Id == raspor.ManageRightsFrom.Id).FirstOrDefault();
            a.ManageRightsTo = db.ManageRights.Where(x => x.Id == raspor.ManageRightsTo.Id).FirstOrDefault();
            a.TypeOfProperty = db.TypeOfPropertyModels.Where(x => x.Id == raspor.TypeOfProperty.Id).FirstOrDefault();
            a.RecipientAgency = db.Agency.Where(x => x.Id == raspor.RecipientAgency.Id).Include(x => x.Acronym).FirstOrDefault();
            a.TransferAgency = db.Agency.Where(x => x.Id == raspor.TransferAgency.Id).Include(x => x.Acronym).FirstOrDefault();
            var ChangeDic = CreateAgencies(a, raspor);

            
            ChangeDic.Add("Objects", "объекта/объектов");
            ChangeDic.Add("Pins", "закрепленного/закрепленных");
            ChangeDic.Add("AdditionalInfo", a.AddInfo);
            ChangeDic.Add("PropertyDiscription",$" - {a.PropertyDiscription},");

            return ChangeDic;
        }
        public Dictionary<string, string> CreateDeny(RequestModel raspor)
        {
            var a = raspor;
            a.ManageRightsFrom = db.ManageRights.Where(x => x.Id == raspor.ManageRightsFrom.Id).FirstOrDefault();
            a.ManageRightsTo = db.ManageRights.Where(x => x.Id == raspor.ManageRightsTo.Id).FirstOrDefault();
            a.TypeOfProperty = db.TypeOfPropertyModels.Where(x => x.Id == raspor.TypeOfProperty.Id).FirstOrDefault();
            a.RecipientAgency = db.Agency.Where(x => x.Id == raspor.RecipientAgency.Id).Include(x => x.Acronym).FirstOrDefault();
            a.TransferAgency = db.Agency.Where(x => x.Id == raspor.TransferAgency.Id).Include(x => x.Acronym).FirstOrDefault();
            var ChangeDic = CreateAgencies(a, raspor);

            ChangeDic.Add("Objects", "объект/объекты");
            ChangeDic.Add("SecObj", "данного объекта/данных объектов");
            ChangeDic.Add("AdditionalInfo", a.AddInfo);
            ChangeDic.Add("PropertyDiscription", $" - {a.PropertyDiscription},");

            return ChangeDic;
        }


    }
}
