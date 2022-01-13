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
@Table(name = "GOI_SAN_PHAM")
public class GoiSanPham {
    @Id
    private int MA_GOI_SP;
    private String TEN_GOI_SP;
}
