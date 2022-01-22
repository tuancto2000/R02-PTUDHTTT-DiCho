package com.example.DiChoThue.Repository;

import com.example.DiChoThue.Entities.DiaChi;
import com.example.DiChoThue.Models.GetNearestStoreResponseModel;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.jpa.repository.query.Procedure;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
public interface DiaChiRepository extends JpaRepository<DiaChi, Integer> {
    @Query("select dc from DiaChi dc where dc.ma_dia_chi = ?1")
    DiaChi getAddressById(int addressId);

//    @Procedure(procedureName = "GetNearestPostCode")
//    List<GetNearestStoreResponseModel> getNearestAddress(int userId);
@Procedure(procedureName = "GetNearestPostCode")
int getNearestAddress(@Param("userId") int userId);
}
