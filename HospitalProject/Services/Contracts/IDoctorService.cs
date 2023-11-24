﻿using HospitalProject.Entities.Dtos;

namespace HospitalProject.Services.Contracts
{
    public interface IDoctorService
    {
        Task<DoctorDtoForRead> GetDoctorByIdAsync(int id, bool trackChanges);
        Task<IEnumerable<DoctorDtoForRead>> GetAllDoctorsAsync(bool trackChanges);
        Task CreateDoctor(DoctorDtoForCreation doctorDto);
        Task UpdateDoctor(int id, DoctorDtoForUpdate doctorDto);
        Task DeleteDoctor(int id, bool trackChanges);
    }
}
