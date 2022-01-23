package com.example.DiChoThue.Repository;

import com.example.DiChoThue.Entities.DiaChi;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;

@Repository
public interface DiaChiRepository extends JpaRepository<DiaChi, Integer> {
    @Query("select dc from DiaChi dc where dc.ma_dia_chi = ?1")
    DiaChi getAddressById(int addressId);
}
