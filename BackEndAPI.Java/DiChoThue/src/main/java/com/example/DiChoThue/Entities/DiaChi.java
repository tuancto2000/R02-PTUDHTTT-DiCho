package com.example.DiChoThue.Entities;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import javax.persistence.*;

@Data
@AllArgsConstructor
@NoArgsConstructor
@Entity
@Table(name = "DIA_CHI")
public class DiaChi {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private int ma_dia_chi;
    private String ten_dia_chi;
    private int toa_do_dong;
    private int toa_do_bac;
    private int loai_vung;
}
