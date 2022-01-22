package com.example.DiChoThue.Repository;

import com.example.DiChoThue.Entities.DonHang;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;

import java.util.Date;

@Repository
public interface DonHangRepository extends JpaRepository<DonHang, Integer> {
    @Query(nativeQuery = true, value = "select top 1 (dh.ngay_mua) from Don_Hang dh where dh.ma_cua_hang = ?1 order by dh.ngay_mua asc")
    Date getOldestSellDate(int storeId);
}
