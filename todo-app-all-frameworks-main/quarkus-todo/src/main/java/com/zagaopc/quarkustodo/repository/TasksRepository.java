package com.zagaopc.quarkustodo.repository;

import com.zagaopc.quarkustodo.model.entity.Tasks;

import io.quarkus.hibernate.orm.panache.PanacheQuery;
import io.quarkus.hibernate.orm.panache.PanacheRepository;
import jakarta.enterprise.context.ApplicationScoped;

@ApplicationScoped
public class TasksRepository implements PanacheRepository<Tasks> {
        
        public Tasks findById(Integer id) {
        return find("id", id).firstResult();
        }

        public boolean existsByName(String name) {
        PanacheQuery<Tasks> query = find("name = ?1", name);
        return query.count() > 0;
        }

}
