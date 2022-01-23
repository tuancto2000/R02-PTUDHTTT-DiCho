package com.example.DiChoThue.Models;

import com.example.DiChoThue.Entities.HinhAnh;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.util.List;

@Data
@AllArgsConstructor
@NoArgsConstructor
public class GetProductByIdModel {
    private SanPhamModel sanpham;
    private List<HinhAnh> hinhanh;
}
