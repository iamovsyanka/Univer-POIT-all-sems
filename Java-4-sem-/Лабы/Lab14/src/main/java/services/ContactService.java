package services;

import exception.RepositoryException;
import exception.ServiceException;
import models.Contact;
import repository.ContactRepository;
import repository.RepositoryCreator;

import java.util.List;

public class ContactService {
    public List<Contact> findAll() throws ServiceException {
        try (RepositoryCreator repositoryCreator = new RepositoryCreator()) {
            ContactRepository contactRepository = repositoryCreator.getContactRepository();
            return contactRepository.findAll();
        } catch (RepositoryException e) {
            throw new ServiceException(e.getMessage(), e);
        }
    }

    public void save(Contact contact) throws ServiceException {
        try (RepositoryCreator repositoryCreator = new RepositoryCreator()) {
            ContactRepository contactRepositoryRepository = repositoryCreator.getContactRepository();
            contactRepositoryRepository.save(contact);
        } catch (RepositoryException exception) {
            throw new ServiceException(exception.getMessage(), exception);
        }
    }

    public void deleteByName(String name) {
        try (RepositoryCreator repositoryCreator = new RepositoryCreator()) {
            ContactRepository contactRepository = repositoryCreator.getContactRepository();
            contactRepository.deleteByName(name);
        }
    }
}