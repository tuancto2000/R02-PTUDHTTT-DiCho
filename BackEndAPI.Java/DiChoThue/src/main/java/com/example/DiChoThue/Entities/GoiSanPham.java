package com.example.DiChoThue.Entities;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import javax.persistence.*;

@Data
@AllArgsConstructor
@NoArgsConstructor
@Entity
@Table(name = "GOI_SAN_PHAM")
public class GoiSanPham {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private int ma_goi_sp;
    private String ten_goi_sp;
}
