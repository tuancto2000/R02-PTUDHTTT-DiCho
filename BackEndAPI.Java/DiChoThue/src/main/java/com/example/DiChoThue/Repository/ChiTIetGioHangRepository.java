package com.example.DiChoThue.Repository;

import com.example.DiChoThue.Entities.ChiTietGioHang;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;

import javax.transaction.Transactional;
import java.util.List;

@Repository
public interface ChiTIetGioHangRepository extends JpaRepository<ChiTietGioHang, Integer> {
    @Query("select ctgh from ChiTietGioHang ctgh where ctgh.ma_gio_hang = ?1")
    List<ChiTietGioHang> getCartDetailsByCartId(int cartId);

    @Transactional
    @Modifying
    @Query("update ChiTietGioHang set so_luong = ?1 where ma_gio_hang = ?2 and ma_sp = ?3")
    void updateQuantity(int quantity, int cartId, int productId);

    @Query("select id from ChiTietGioHang where ma_gio_hang = ?1 and ma_sp = ?2")
    int checkExistsProduct(int cartId, int productId);

    @Transactional
    @Modifying
    @Query("update ChiTietGioHang set so_luong = so_luong + ?1 where Id = ?2")
    void updateQuantityByCartDetailId(int quantity, int cartDetailId);
}
