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

    @Query("select sp from SanPham sp where sp.ma_dm = ?1 order by sp.trungbinhsao desc")
    Page<SanPham> findByCategoryId(int categoryId, Pageable pageable);

    @Query("select sp from SanPham sp order by sp.trungbinhsao desc")
    Page<SanPham> findAll(Pageable pageable);
}
