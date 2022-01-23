package com.example.DiChoThue.Repository;

import com.example.DiChoThue.Entities.SanPham;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;

import javax.transaction.Transactional;

@Repository
public interface SanPhamRepository extends JpaRepository<SanPham, Integer> {
    @Transactional
    @Modifying
    @Query("update SanPham set trang_thai = 0 where ma_sp = ?1")
    void changeState(int productId);
}
