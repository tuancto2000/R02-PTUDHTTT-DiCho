package com.example.DiChoThue.Entities;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Table;

@Data
@AllArgsConstructor
@NoArgsConstructor
@Entity
@Table(name = "CHI_TIET_GOI_SAN_PHAM")
public class ChiTietGoiSanPham {
    @Id
    private int Id;
    private int MA_SP;
    private int MA_GOI_SP;
    private int SO_LUONG;
}
