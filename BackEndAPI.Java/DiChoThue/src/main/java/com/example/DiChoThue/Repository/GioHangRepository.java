package com.example.DiChoThue.Repository;

import com.example.DiChoThue.Entities.GioHang;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;

@Repository
public interface GioHangRepository extends JpaRepository<GioHang, Integer> {
    @Query("select ma_gio_hang from GioHang where ma_nguoi_dung = ?1")
    int getCartId(int userId);
}
