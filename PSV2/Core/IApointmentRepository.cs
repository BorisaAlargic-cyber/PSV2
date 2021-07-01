﻿using System;
using System.Collections.Generic;
using PSV2.Model;
using static PSV2.Core.IRepository;

namespace PSV2.Core
{
    public interface IApointmentRepository : IRepository<Apointment>
    {
        public List<Apointment> SearchApointmens(PriorityRequest priorityReq);

        public List<Apointment> FirstTimeApointments(User patient);
    }
}
