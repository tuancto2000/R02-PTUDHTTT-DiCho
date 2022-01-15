package com.example.DiChoThue.Controllers;

import com.example.DiChoThue.Entities.NguoiDung;
import com.example.DiChoThue.Models.NguoiDungModel;
import com.example.DiChoThue.Repository.NguoiDungRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import javax.persistence.EntityManager;
import javax.persistence.Query;
import java.util.List;

@RestController
@RequestMapping("/api/statistics")
public class StatisticsController {
    @Autowired
    NguoiDungRepository nguoiDungRepository;

    @Autowired
    private EntityManager entityManager;

    @GetMapping("/customers")
    public List<NguoiDungModel> getAllCustomers() {
        String sql = "Select new " + NguoiDungModel.class.getName() //
                + "(e.MA_NGUOI_DUNG, e.TEN_NGUOI_DUNG,e.NGAY_SINH, e.DIA_CHI, e.SDT, e.EMAIL) " //
                + " from " + NguoiDung.class.getName() + " e where e.VAI_TRO = 0";
        Query query = entityManager.createQuery(sql, NguoiDungModel.class);
        return query.getResultList();
    }

    @GetMapping("/shops")
    public List<NguoiDungModel> getAllShops() {
        String sql = "Select new " + NguoiDungModel.class.getName() //
                + "(e.MA_NGUOI_DUNG, e.TEN_NGUOI_DUNG,e.NGAY_SINH, e.DIA_CHI, e.SDT, e.EMAIL) " //
                + " from " + NguoiDung.class.getName() + " e where e.VAI_TRO = 1";
        Query query = entityManager.createQuery(sql, NguoiDungModel.class);
        return query.getResultList();
    }

    @GetMapping("/shippers")
    public List<NguoiDungModel> getAllShippers() {
        String sql = "Select new " + NguoiDungModel.class.getName() //
                + "(e.MA_NGUOI_DUNG, e.TEN_NGUOI_DUNG,e.NGAY_SINH, e.DIA_CHI, e.SDT, e.EMAIL) " //
                + " from " + NguoiDung.class.getName() + " e where e.VAI_TRO = 2";
        Query query = entityManager.createQuery(sql, NguoiDungModel.class);
        return query.getResultList();
    }
}
