package com.example.DiChoThue.Entities;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import javax.persistence.*;
import java.util.Date;

@Data
@AllArgsConstructor
@NoArgsConstructor
@Entity
@Table(name = "NGUOI_DUNG")
///@SQLInsert(sql = "insert into NGUOI_DUNG (TEN_NGUOI_DUNG, NGAY_SINH, DIA_CHI, SDT, EMAIL, VAI_TRO) values (?, ?, ?, ?, ?, ?)")
public class NguoiDung {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private int ma_nguoi_dung;
    private String ten_nguoi_dung;
    private Date ngay_sinh;
    private String dia_chi;
    private String sdt;
    private String email;
    private String vai_tro;
}
