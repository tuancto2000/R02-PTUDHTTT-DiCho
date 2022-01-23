package com.example.DiChoThue.Controllers;

import com.example.DiChoThue.Entities.CuaHang;
import com.example.DiChoThue.Entities.DanhMuc;
import com.example.DiChoThue.Entities.HinhAnh;
import com.example.DiChoThue.Entities.SanPham;
import com.example.DiChoThue.Exception.ResourceNotFoundException;
import com.example.DiChoThue.Models.CreateProductModel;
import com.example.DiChoThue.Models.GetProductByIdModel;
import com.example.DiChoThue.Models.SanPhamModel;
import com.example.DiChoThue.Models.UpdateProductModel;
import com.example.DiChoThue.Repository.HinhAnhRepository;
import com.example.DiChoThue.Repository.SanPhamRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.PageImpl;
import org.springframework.data.domain.PageRequest;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import javax.persistence.EntityManager;
import javax.validation.Valid;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

@RestController
@RequestMapping("/api/products")
public class ProductsController {
    @Autowired
    SanPhamRepository sanPhamRepository;

    @Autowired
    HinhAnhRepository hinhAnhRepository;

    @Autowired
    private EntityManager entityManager;

    @GetMapping
    public ResponseEntity<Map<String, Object>> getAllProducts(
            @RequestParam(required = false) String productName,
            @RequestParam(defaultValue = "-1") int categoryId,
            @RequestParam(defaultValue = "0") int page,
            @RequestParam(defaultValue = "6") int size)
            throws ResourceNotFoundException {
        try {
            List<SanPham> sanPhams = new ArrayList<SanPham>();
            PageRequest paging = PageRequest.of(page, size);
            Page<SanPham> pageProducts;

            if (productName != null && categoryId != -1) {
                String sql = "Select new " + SanPham.class.getName()
                        + "(sp.ma_sp, sp.ma_cua_hang, sp.ma_dm, sp.ten_sp, sp.gia_sp, sp.so_luong_con_lai, sp.mo_ta, sp.soluotdanhgia, sp.trungbinhsao, sp.trang_thai)"
                        + " from " + SanPham.class.getName() + " sp where sp.ten_sp like '%" + productName + "%' and ma_dm = " + categoryId + "order by sp.trungbinhsao desc";

                List<SanPham> sanPhamList = entityManager
                        .createQuery(sql, SanPham.class)
                        .getResultList();
                final int start = page;
                final int end = Math.min((start + size), sanPhamList.size());
                pageProducts = new PageImpl<SanPham>(sanPhamList.subList(start, end), paging, sanPhamList.size());
            } else if (productName != null) {
                String sql = "Select new " + SanPham.class.getName()
                        + "(sp.ma_sp, sp.ma_cua_hang, sp.ma_dm, sp.ten_sp, sp.gia_sp, sp.so_luong_con_lai, sp.mo_ta, sp.soluotdanhgia, sp.trungbinhsao, sp.trang_thai)"
                        + " from " + SanPham.class.getName() + " sp where sp.ten_sp like '%" + productName + "%'" + "order by sp.trungbinhsao desc";

                List<SanPham> sanPhamList = entityManager
                        .createQuery(sql, SanPham.class)
                        .getResultList();
                final int start = page;
                final int end = Math.min((start + size), sanPhamList.size());
                pageProducts = new PageImpl<SanPham>(sanPhamList.subList(start, end), paging, sanPhamList.size());
            } else if (categoryId != -1) {
                pageProducts = sanPhamRepository.findByCategoryId(categoryId, paging);
            } else {
                pageProducts = sanPhamRepository.findAll(paging);
            }

            sanPhams = pageProducts.getContent();

            Map<String, Object> response = new HashMap<>();
            response.put("sanphams", sanPhams);
            response.put("currentPage", pageProducts.getNumber());
            response.put("totalItems", pageProducts.getTotalElements());
            response.put("totalPages", pageProducts.getTotalPages());

            return new ResponseEntity<>(response, HttpStatus.OK);
        } catch (Exception e) {
            return new ResponseEntity<>(null, HttpStatus.INTERNAL_SERVER_ERROR);
        }
    }

    @GetMapping("/store/{storeId}")
    public ResponseEntity<Map<String, Object>> getAllProductsOfStore(@PathVariable(value = "storeId") Integer storeId,
                                                                     @RequestParam(defaultValue = "0") int page,
                                                                     @RequestParam(defaultValue = "6") int size)
            throws ResourceNotFoundException {
        try {
            List<SanPhamModel> sanPhams = new ArrayList<SanPhamModel>();
            PageRequest paging = PageRequest.of(page, size);
            Page<SanPhamModel> pageProducts;

            String sql = "Select new " + SanPhamModel.class.getName()
                    + "(sp.ma_sp, sp.ten_sp, dm.ma_dm, dm.ten_dm, sp.ma_cua_hang, ch.ten_cua_hang, sp.gia_sp, sp.so_luong_con_lai, sp.mo_ta, sp.soluotdanhgia, sp.trungbinhsao) "
                    + " from " + SanPham.class.getName() + " sp join " + DanhMuc.class.getName()
                    + " dm on sp.ma_dm = dm.ma_dm join " + CuaHang.class.getName() + " ch on sp.ma_cua_hang = ch.ma_cua_hang "
                    + "where sp.ma_cua_hang = " + storeId + "order by sp.trungbinhsao desc";
            List<SanPhamModel> sanPhamModels = entityManager.createQuery(sql, SanPhamModel.class).getResultList();

            final int start = page;
            final int end = Math.min((start + size), sanPhamModels.size());
            pageProducts = new PageImpl<SanPhamModel>(sanPhamModels.subList(start, end), paging, sanPhamModels.size());


            sanPhams = pageProducts.getContent();

            Map<String, Object> response = new HashMap<>();
            response.put("sanphams", sanPhams);
            response.put("currentPage", pageProducts.getNumber());
            response.put("totalItems", pageProducts.getTotalElements());
            response.put("totalPages", pageProducts.getTotalPages());

            return new ResponseEntity<>(response, HttpStatus.OK);
        } catch (Exception e) {
            return new ResponseEntity<>(null, HttpStatus.INTERNAL_SERVER_ERROR);
        }


//        String sql = "Select new " + SanPhamModel.class.getName()
//                + "(sp.ma_sp, sp.ten_sp, dm.ma_dm, dm.ten_dm, sp.ma_cua_hang, ch.ten_cua_hang, sp.gia_sp, sp.so_luong_con_lai, sp.mo_ta, sp.soluotdanhgia, sp.trungbinhsao) "
//                + " from " + SanPham.class.getName() + " sp join " + DanhMuc.class.getName()
//                + " dm on sp.ma_dm = dm.ma_dm join " + CuaHang.class.getName() + " ch on sp.ma_cua_hang = ch.ma_cua_hang "
//                + "where sp.ma_cua_hang = " + storeId;
//        Query query = entityManager.createQuery(sql, SanPhamModel.class);
//        return ResponseEntity.ok().body(query.getResultList());
    }

    @GetMapping("/{productId}")
    public ResponseEntity<GetProductByIdModel> getProductById(@PathVariable(value = "productId") Integer productId)
            throws ResourceNotFoundException {
        String sql = "Select new " + SanPhamModel.class.getName()
                + "(sp.ma_sp, sp.ten_sp, dm.ma_dm, dm.ten_dm, sp.ma_cua_hang, ch.ten_cua_hang, sp.gia_sp, sp.so_luong_con_lai, sp.mo_ta, sp.soluotdanhgia, sp.trungbinhsao) "
                + " from " + SanPham.class.getName() + " sp join " + DanhMuc.class.getName()
                + " dm on sp.ma_dm = dm.ma_dm join " + CuaHang.class.getName() + " ch on sp.ma_cua_hang = ch.ma_cua_hang "
                + "where sp.ma_sp = " + productId;
        SanPhamModel sanPhamModel = entityManager.createQuery(sql, SanPhamModel.class).getSingleResult();
        List<HinhAnh> listHinhAnh = hinhAnhRepository.getImByProductId(sanPhamModel.getMa_sp());

        GetProductByIdModel product = new GetProductByIdModel(sanPhamModel, listHinhAnh);
        return ResponseEntity.ok().body(product);
    }

    @PostMapping
    public ResponseEntity<Integer> createProduct(@Valid @RequestBody CreateProductModel product) {
        SanPham sanPham = new SanPham();

        sanPham.setMa_cua_hang(product.getMa_cua_hang());
        sanPham.setMa_dm(product.getMa_dm());
        sanPham.setTen_sp(product.getTen_sp());
        sanPham.setGia_sp(product.getGia_sp());
        sanPham.setSo_luong_con_lai(product.getSo_luong_con_lai());
        sanPham.setMo_ta(product.getMo_ta());

        int productId = sanPhamRepository.save(sanPham).getMa_sp();

        for (HinhAnh ha : product.getHinh_anh()) {
            ha.setMa_sp(productId);
            hinhAnhRepository.save(ha);
        }

        return ResponseEntity.ok(productId);
    }

    @PutMapping("/{productId}")
    public ResponseEntity<Boolean> updateProduct(@PathVariable(value = "productId") Integer productId,
                                                 @Valid @RequestBody UpdateProductModel sanPhamDetail)
            throws ResourceNotFoundException {
        SanPham sanPham = sanPhamRepository.findById(productId)
                .orElseThrow(() -> new ResourceNotFoundException("Product not found for this id :: " + productId));

        sanPham.setTen_sp(sanPhamDetail.getTen_sp());
        sanPham.setMo_ta(sanPhamDetail.getMo_ta());
        sanPham.setGia_sp(sanPhamDetail.getGia_sp());
        sanPham.setSo_luong_con_lai(sanPham.getSo_luong_con_lai() + sanPhamDetail.getSo_luong_con_lai());
        sanPham.setMa_dm(sanPhamDetail.getMa_dm());

        sanPhamRepository.save(sanPham);
        List<HinhAnh> listHinhAnhNew = sanPhamDetail.getHinh_anh();
        List<HinhAnh> listHinhAnhOld = hinhAnhRepository.getImByProductId(productId);

        if (listHinhAnhNew != null) {
            for (HinhAnh ha : listHinhAnhOld) {
                if (!listHinhAnhNew.contains(ha)) {
                    hinhAnhRepository.delete(ha);
                }
            }

            for (HinhAnh ha : listHinhAnhNew) {
                if (ha.getMa_hinh_anh() == 0) {
                    hinhAnhRepository.save(ha);
                }
            }
        }

        return ResponseEntity.ok(Boolean.TRUE);
    }

    @DeleteMapping("/{productId}")
    public ResponseEntity<Boolean> deleteProduct(@PathVariable(value = "productId") Integer productId)
            throws ResourceNotFoundException {
        SanPham sanPham = sanPhamRepository.findById(productId)
                .orElseThrow(() -> new ResourceNotFoundException("Product not found for this id :: " + productId));

        sanPhamRepository.changeState(productId);

        return ResponseEntity.ok(Boolean.TRUE);
    }
}
