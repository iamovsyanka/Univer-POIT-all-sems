<?php
namespace Drupal\slogan_config_override\Config;

use Drupal\Core\Cache\CacheableMetadata;
use Drupal\Core\Config\ConfigFactoryOverrideInterface;
use Drupal\Core\Config\StorageInterface;

/**
 * Example configuration override.
 */
class ConfigExampleOverrides implements ConfigFactoryOverrideInterface {

    /**
     * {@inheritdoc}
     */
    public function loadOverrides($names) {
        $overrides = array();
        if (in_array('system.site', $names)) {
            $overrides['system.site'] = ['name' => 'Работает - не трогай!!!!!!!!!!!!!!'];
        }
        return $overrides;
    }

    /**
     * {@inheritdoc}
     */
    public function getCacheSuffix() {
        return 'ConfigExampleOverrider';
    }

    /**
     * {@inheritdoc}
     */
    public function getCacheableMetadata($name) {
        return new CacheableMetadata();
    }

    /**
     * {@inheritdoc}
     */
    public function createConfigObject($name, $collection = StorageInterface::DEFAULT_COLLECTION) {
        return NULL;
    }

}