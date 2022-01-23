package com.example.DiChoThue.Repository;

import com.example.DiChoThue.Entities.HinhAnh;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
public interface HinhAnhRepository extends JpaRepository<HinhAnh, Integer> {
    @Query("select ha from HinhAnh ha where ha.ma_sp = ?1  order by ha.mac_dinh desc")
    List<HinhAnh> getImgByProductId(int productId);
}
