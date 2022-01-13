package com.example.DiChoThue.Repository;

import com.example.DiChoThue.Entities.ChiTietGoiSanPham;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface ChiTIetGoiSanPhamRepository extends JpaRepository<ChiTietGoiSanPham, Integer> {

}
