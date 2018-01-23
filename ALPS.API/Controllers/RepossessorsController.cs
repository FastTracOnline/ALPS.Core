using ALPS.Repository;
using Marvin.JsonPatch;
using System;
using System.Linq;
using System.Web.Http;
using Repossessor = ALPS.Repository.Entities.Repossessor;

namespace ALPS.API.Controllers
{
    public class RepossessorsController : ApiBaseController
    {
        const int maxPageSize = 100;

        public RepossessorsController(IUow uow)
        {
            Uow = uow;
        }

        #region OData Future: IQueryable<T>
        //[Queryable]
        // public IQueryable<Repossessor> Get()
        #endregion

        //[ResourceAuthorize("List", "Repossessors")]
        public IHttpActionResult Get()
        {
            try
            { 
                //System.Security.Claims.Claim iss = null, sub = null;
                //var identity = this.User.Identity as ClaimsIdentity;

                //if (identity != null)
                //{
                //    iss = identity.FindFirst("iss");
                //    sub = identity.FindFirst("sub");
                //}

                //// set the user id to this key
                //if (iss != null && sub != null)
                //{
                //    userId = iss.Value + "_" + sub.Value;
                //}
                //else
                //{
                //    // if there's no unique key, we shouldn't be able to continue
                //    return StatusCode(HttpStatusCode.Forbidden);
                //}

                //var list = Uow.Repossessors.GetAll().ApplySort(sort);

                var list = Uow.Repossessors.GetAll();
                var result = list.ToList().Select(x => Map(x));

                //// ensure the page size isn't larger than the maximum.
                //if (pageSize > maxPageSize)
                //{
                //    pageSize = maxPageSize;
                //}

                //// calculate data for metadata
                //var totalCount = list.Count();
                //var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

                //var urlHelper = new UrlHelper(Request);
                //var prevLink = page > 1 ? urlHelper.Link("RepossessorList",
                //    new
                //    {
                //        page = page - 1,
                //        pageSize = pageSize,
                //        sort = sort
                //    }) : "";
                //var nextLink = page < totalPages ? urlHelper.Link("RepossessorList",
                //    new
                //    {
                //        page = page + 1,
                //        pageSize = pageSize,
                //        sort = sort
                //    }) : "";


                //var paginationHeader = new
                //{
                //    currentPage = page,
                //    pageSize = pageSize,
                //    totalCount = totalCount,
                //    totalPages = totalPages,
                //    previousPageLink = prevLink,
                //    nextPageLink = nextLink
                //};

                //HttpContext.Current.Response.Headers.Add("X-Pagination",
                //   Newtonsoft.Json.JsonConvert.SerializeObject(paginationHeader));

                //var z = list
                //    .Skip(pageSize * (page - 1))
                //    .Take(pageSize);

                //var x = new List<RepossessorList>();
                //foreach (Repossessor y in z)
                //{
                //    var entry = RepossessorListMap.Create(y);
                //    x.Add(entry);
                //}

                // return result
                return Ok(result.ToList());
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        //[ResourceAuthorize("Read", "Repossessors")]
        // GET /api/Repossessors/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                var repossessor = Uow.Repossessors.GetById(id);
                if (repossessor != null)
                {
                    var existingRepossessor = Map(repossessor);
                    return Ok(existingRepossessor);
                }
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // Create a new Repossessor
        //[ResourceAuthorize("Create", "Repossessors")]
        // POST /api/Repossessor
        public IHttpActionResult Post(DTO.Repossessor repossessor)
        {
            try
            {
                if (!repossessor.IsValid())
                    return BadRequest("One or more fields have invalid data.");

                var newRepossessor = Map(repossessor);

                // New repossessor is always active and always gets their dates initialized
                newRepossessor.Active = true;
                newRepossessor.Created = DateTime.UtcNow;
                newRepossessor.Updated = DateTime.UtcNow;

                Uow.Repossessors.Add(newRepossessor);

                if (Uow.Commit() > 0)
                {
                    return Ok(Map(newRepossessor));
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        //[ResourceAuthorize("Update", "Repossessors")]
        public IHttpActionResult Put(DTO.Repossessor repossessor)
        {
            try
            {
                var oldRepossessor = Uow.Repossessors.GetById(repossessor.Id);
                if (oldRepossessor == null)
                    return NotFound();

                var newRepossessor = Map(repossessor);
                newRepossessor.Updated = DateTime.UtcNow;

                oldRepossessor = PatchUp(oldRepossessor, newRepossessor);

                Uow.Repossessors.Update(oldRepossessor);

                if (Uow.Commit() > 0)
                {
                    return Ok(oldRepossessor);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        //[ResourceAuthorize("Update", "Repossessors")]
        public IHttpActionResult Patch(int id, [FromBody]JsonPatchDocument<DTO.Repossessor> patchDocument)
        {
            try
            {
                var oldRecord = Uow.Repossessors.GetById(id);
                if (oldRecord == null)
                    return NotFound();

                var updateRecord = Map(oldRecord);
                patchDocument.ApplyTo(updateRecord);
                oldRecord = Map(updateRecord);
                Uow.Repossessors.Update(oldRecord);

                if (Uow.Commit() > 0)
                {
                    return Ok(oldRecord);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        //[ResourceAuthorize("Delete", "Repossessors")]
        public IHttpActionResult Delete(DTO.Repossessor repossessor)
        {
            repossessor.Active = false;
            return Put(repossessor);
        }

        internal static DTO.Repossessor Map(Repossessor recordIn)
        {
            if (recordIn == null)
                return null;

            var recordOut = new DTO.Repossessor
            {
                Id = recordIn.Id,
                CompanyName = recordIn.CompanyName,
                CompanyType = recordIn.CompanyType,
                PrimaryContact = recordIn.PrimaryContact,
                PrimaryAddress = recordIn.PrimaryAddress,
                PrimaryCity = recordIn.PrimaryCity,
                PrimaryState = recordIn.PrimaryState,
                PrimaryZip = recordIn.PrimaryZip,
                PrimaryPhone = recordIn.PrimaryPhone,
                PrimaryMobile = recordIn.PrimaryMobile,
                PrimaryFax = recordIn.PrimaryFax,
                PrimaryEmail = recordIn.PrimaryEmail,
                Notes = recordIn.Notes,
                Active = recordIn.Active,
                Created = recordIn.Created,
                Updated = recordIn.Updated,
                Version = recordIn.Version,
                TenantName = recordIn.TenantName,
                Balance = recordIn.Balance
            };

            return recordOut;
        }

        internal static Repossessor Map(DTO.Repossessor recordIn)
        {
            if (recordIn == null)
                return null;

            var recordOut = new Repossessor
            {
                Id = recordIn.Id,
                CompanyName = recordIn.CompanyName,
                CompanyType = recordIn.CompanyType,
                PrimaryContact = recordIn.PrimaryContact,
                PrimaryAddress = recordIn.PrimaryAddress,
                PrimaryCity = recordIn.PrimaryCity,
                PrimaryState = recordIn.PrimaryState,
                PrimaryZip = recordIn.PrimaryZip,
                PrimaryPhone = recordIn.PrimaryPhone,
                PrimaryMobile = recordIn.PrimaryMobile,
                PrimaryFax = recordIn.PrimaryFax,
                PrimaryEmail = recordIn.PrimaryEmail,
                Notes = recordIn.Notes,
                Active = recordIn.Active,
                Created = recordIn.Created,
                Updated = recordIn.Updated,
                Version = recordIn.Version,
                TenantName = recordIn.TenantName,
                Balance = recordIn.Balance
            };

            return recordOut;
        }

        internal static Repossessor PatchUp(Repossessor oldRecord, Repossessor newRecord)
        {
            if (oldRecord == null || newRecord == null)
                return oldRecord;

            oldRecord.CompanyName = newRecord.CompanyName;
            oldRecord.CompanyType = newRecord.CompanyType;
            oldRecord.PrimaryContact = newRecord.PrimaryContact;
            oldRecord.PrimaryAddress = newRecord.PrimaryAddress;
            oldRecord.PrimaryCity = newRecord.PrimaryCity;
            oldRecord.PrimaryState = newRecord.PrimaryState;
            oldRecord.PrimaryZip = newRecord.PrimaryZip;
            oldRecord.PrimaryPhone = newRecord.PrimaryPhone;
            oldRecord.PrimaryMobile = newRecord.PrimaryMobile;
            oldRecord.PrimaryFax = newRecord.PrimaryFax;
            oldRecord.PrimaryEmail = newRecord.PrimaryEmail;
            oldRecord.Notes = newRecord.Notes;
            oldRecord.Active = newRecord.Active;
            oldRecord.Created = (newRecord.Created == DateTime.MinValue) ? DateTime.UtcNow : newRecord.Created;
            oldRecord.Updated = (newRecord.Updated == DateTime.MinValue) ? DateTime.UtcNow : newRecord.Updated;
            oldRecord.TenantName = newRecord.TenantName;
            oldRecord.Balance = newRecord.Balance;

            return oldRecord;
        }
    }
}
