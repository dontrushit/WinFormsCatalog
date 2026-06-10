CREATE TABLE IF NOT EXISTS phones (
    id    SERIAL PRIMARY KEY,
    model VARCHAR(255) NOT NULL
);

CREATE TABLE IF NOT EXISTS characteristics (
    id                  SERIAL PRIMARY KEY,
    phone_id            INTEGER NOT NULL UNIQUE REFERENCES phones(id) ON DELETE CASCADE,
    producer            VARCHAR(100) NOT NULL DEFAULT '',
    os                  VARCHAR(50) NOT NULL DEFAULT '',
    screen_size         VARCHAR(20) NOT NULL DEFAULT '',
    ram_gb              INTEGER NOT NULL DEFAULT 0,
    storage_gb          INTEGER NOT NULL DEFAULT 0,
    image_url           VARCHAR(255) NOT NULL DEFAULT '',
    in_stock            BOOLEAN NOT NULL DEFAULT TRUE,
    screen_tech         VARCHAR(50) NOT NULL DEFAULT '',
    screen_resolution   VARCHAR(30) NOT NULL DEFAULT '',
    screen_refresh_hz   INTEGER NOT NULL DEFAULT 0,
    processor           VARCHAR(100) NOT NULL DEFAULT '',
    camera_mp           INTEGER NOT NULL DEFAULT 0,
    battery_mah         INTEGER NOT NULL DEFAULT 0,
    waterproof          VARCHAR(50) NOT NULL DEFAULT '',
    description         TEXT NOT NULL DEFAULT ''
);

CREATE TABLE IF NOT EXISTS shops (
    id       SERIAL PRIMARY KEY,
    phone_id INTEGER NOT NULL REFERENCES phones(id) ON DELETE CASCADE,
    shop     VARCHAR(100) NOT NULL,
    price    NUMERIC(12, 2) NOT NULL
);

CREATE TABLE IF NOT EXISTS orders (
    id              SERIAL PRIMARY KEY,
    phone_id        INTEGER NOT NULL REFERENCES phones(id) ON DELETE RESTRICT,
    shop_name       VARCHAR(100) NOT NULL,
    unit_price      NUMERIC(12, 2) NOT NULL,
    quantity        INTEGER NOT NULL,
    customer_name   VARCHAR(255) NOT NULL,
    customer_phone  VARCHAR(50) NOT NULL,
    address         TEXT,
    created_at      TIMESTAMPTZ NOT NULL DEFAULT NOW()
);

CREATE INDEX IF NOT EXISTS IX_characteristics_phone_id ON characteristics(phone_id);
CREATE INDEX IF NOT EXISTS IX_shops_phone_id ON shops(phone_id);
CREATE INDEX IF NOT EXISTS IX_orders_phone_id ON orders(phone_id);
CREATE INDEX IF NOT EXISTS IX_orders_created_at ON orders(created_at);

CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId"    VARCHAR(150) NOT NULL PRIMARY KEY,
    "ProductVersion" VARCHAR(32)  NOT NULL
);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES
    ('20260606210411_InitialCreate', '9.0.6'),
    ('20260606210427_SeedCatalogData', '9.0.6')
ON CONFLICT ("MigrationId") DO NOTHING;

-- Seed (только если каталог пустой)
DO $$
BEGIN
    IF NOT EXISTS (SELECT 1 FROM phones LIMIT 1) THEN
        INSERT INTO phones (id, model) VALUES
        (1, 'Xiaomi Redmi Note 15 Pro 5G 8GB/256GB'),
        (2, 'Infinix Note 50 X6858 8GB/256GB (сумрачный черный)'),
        (3, 'Infinix Hot 60 Pro X6885 8GB/256GB (серебристый)'),
        (4, 'Apple iPhone 17 256GB (черный)'),
        (5, 'Samsung Galaxy S26 SM-S942B 12GB/256GB (черный)'),
        (6, 'Samsung Galaxy S25 Ultra SM-S938B 12GB/256GB (черный титан)'),
        (7, 'Google Pixel 9 8GB/128GB'),
        (8, 'HONOR 200 12GB/256GB'),
        (9, 'Samsung Galaxy A55 5G 8GB/256GB'),
        (10, 'Apple iPhone 15 6GB/128GB'),
        (11, 'Realme GT Neo 6 12GB/256GB'),
        (12, 'OnePlus 13 12GB/256GB'),
        (13, 'Xiaomi 14T Pro 12GB/512GB'),
        (14, 'Realme GT 6 12GB/256GB'),
        (15, 'Nothing Phone (3) 12GB/256GB'),
        (16, 'Sony Xperia 1 VI 12GB/256GB'),
        (17, 'Huawei P70 Pro 12GB/512GB');

        PERFORM setval(pg_get_serial_sequence('phones', 'id'), (SELECT MAX(id) FROM phones));

        INSERT INTO characteristics (phone_id, producer, os, screen_size, ram_gb, storage_gb, image_url, in_stock, screen_tech, screen_resolution, screen_refresh_hz, processor, camera_mp, battery_mah, waterproof, description) VALUES
        (1, 'Xiaomi', 'Android', '6.83', 8, 256, 'placeholder.png', TRUE, 'AMOLED', '1280x2772', 120, 'Mediatek Dimensity 7400 Ultra', 200, 6580, 'IP68/IP69K', 'Флагманский смартфон с AMOLED-экраном 120 Гц, камерой 200 Мп и быстрой зарядкой.'),
        (2, 'Infinix', 'Android', '6.78', 8, 256, 'placeholder.png', TRUE, 'AMOLED', '1080x2436', 144, 'Mediatek Helio G100 Ultimate', 50, 5200, 'IP64', 'Бюджетный смартфон с большим экраном AMOLED 144 Гц.'),
        (3, 'Infinix', 'Android', '6.78', 8, 256, 'placeholder.png', TRUE, 'AMOLED', '1224x2720', 144, 'Mediatek Helio G200', 50, 5160, 'IP64', 'Доступный смартфон с поддержкой карт памяти и AMOLED 144 Гц.'),
        (4, 'Iphone', 'IOS', '6.3', 8, 256, 'placeholder.png', TRUE, 'OLED', '1206x2622', 120, 'Apple A19', 48, 3692, 'IP68', 'Флагман Apple с чипом A19, камерой 48 Мп и экраном OLED 120 Гц.'),
        (5, 'Sumsung', 'Android', '6.3', 12, 256, 'placeholder.png', TRUE, 'AMOLED', '1080x2340', 120, 'Samsung Exynos 2600', 50, 4300, 'IP68', 'Новинка Samsung с Exynos 2600 и влагозащитой IP68.'),
        (6, 'Samsung', 'Android', '6.9', 12, 256, 'placeholder.png', TRUE, 'AMOLED', '1440x3120', 120, 'Qualcomm Snapdragon 8 Elite', 200, 5000, 'IP68', 'Топовый флагман с камерой 200 Мп и QHD+ экраном.'),
        (7, 'Google', 'Android', '6.24', 8, 128, 'placeholder.png', TRUE, 'OLED', '1080x2400', 120, 'Google Tensor G4', 50, 4757, 'IP68', 'Смартфон Google с чипом Tensor G4 и отличной камерой'),
        (8, 'HONOR', 'Android', '6.7', 12, 256, 'placeholder.png', TRUE, 'OLED', '1080x2436', 120, 'Qualcomm Snapdragon 7 Gen 3', 50, 5200, 'IP68', 'Средний класс с OLED-экраном и быстрой зарядкой.'),
        (9, 'Samsung', 'Android', '6.7', 8, 128, 'placeholder.png', TRUE, 'AMOLED', '1080x2340', 120, 'Exynos 1480', 50, 5000, 'IP68', 'Сбалансированный смартфон с хорошей камерой и AMOLED-экраном 120 Гц.'),
        (10, 'Iphone', 'IOS', '6.1', 6, 128, 'placeholder.png', TRUE, 'OLED', '1179x2556', 60, 'Apple A16 Bionic', 48, 3349, 'IP68', 'Популярный флагман Apple с отличной оптимизацией и камерой.'),
        (11, 'Realme', 'Android', '6.78', 12, 256, 'placeholder.png', TRUE, 'AMOLED', '1264x2780', 144, 'Snapdragon 8s Gen 3', 50, 5500, 'IP68', 'Мощный игровой смартфон с топовым процессором и экраном 144 Гц.'),
        (12, 'OnePlus', 'Android', '6.78', 12, 256, 'placeholder.png', TRUE, 'AMOLED', '1440x3168', 120, 'Qualcomm Snapdragon 8 Gen 4', 50, 5400, 'IP68', 'Флагман OnePlus с мощным процессором и быстрой зарядкой.'),
        (13, 'Xiaomi', 'Android', '6.7', 12, 512, 'placeholder.png', TRUE, 'AMOLED', '1220x2712', 120, 'Mediatek Dimensity 9300+', 50, 5000, 'IP68', 'Производительный смартфон с AMOLED 144 Гц и камерой Leica.'),
        (14, 'Realme', 'Android', '6.7', 12, 256, 'placeholder.png', TRUE, 'AMOLED', '1240x2772', 144, 'Qualcomm Snapdragon 8s Gen 3', 50, 5500, 'IP68', 'Мощный смартфон с высокой частотой обновления и быстрой зарядкой.'),
        (15, 'Nothing', 'Android', '6.7', 12, 256, 'placeholder.png', TRUE, 'AMOLED', '1080x2412', 120, 'Qualcomm Snapdragon 8 Gen 3', 50, 5000, 'IP54', 'Стильный смартфон с уникальным дизайном и подсветкой Glyph.'),
        (16, 'Sony', 'Android', '6.5', 12, 256, 'placeholder.png', TRUE, 'OLED', '1644x3840', 120, 'Qualcomm Snapdragon 8 Gen 3', 48, 5000, 'IP68', 'Флагман Sony с 4K OLED-дисплеем и профессиональной камерой.'),
        (17, 'Huawei', 'Android', '6.8', 12, 256, 'placeholder.png', TRUE, 'OLED', '1260x2844', 120, 'Kirin 9010', 50, 5100, 'IP68', 'Флагман Huawei с продвинутой камерой и большим аккумулятором.');

        INSERT INTO shops (phone_id, shop, price) VALUES
        (1, 'DNS', 1150), (1, 'OZON', 1200), (1, 'WildBerries', 1250),
        (2, 'BRU', 600), (2, 'DNS', 689), (2, 'OZON', 650),
        (3, 'DNS', 599), (3, 'OZON', 580),
        (4, 'DNS', 2750), (4, 'OZON', 2850), (4, 'WildBerries', 2900),
        (5, 'BRU', 3399), (5, 'DNS', 2800), (5, 'OZON', 2900),
        (6, 'BRU', 3100), (6, 'DNS', 2800), (6, 'OZON', 2916), (6, 'WildBerries', 2999),
        (7, 'DNS', 1999), (7, 'WildBerries', 2000),
        (8, 'BRU', 1200), (8, 'DNS', 1099), (8, 'WildBerries', 1000),
        (9, 'BRU', 1100), (9, 'DNS', 1220), (9, 'OZON', 1200), (9, 'WildBerries', 1150),
        (10, 'OZON', 1500), (10, 'WildBerries', 1550),
        (11, 'BRU', 2000), (11, 'OZON', 2110), (11, 'WildBerries', 2050),
        (12, 'BRU', 2200), (12, 'WildBerries', 2100),
        (13, 'OZON', 1700), (13, 'WildBerries', 1729),
        (14, 'Magnit', 1400), (14, 'OZON', 1500), (14, 'WildBerries', 1429),
        (15, 'OZON', 1650), (15, 'WildBerries', 1600),
        (16, 'Magnit', 2630), (16, 'WildBerries', 2600),
        (17, 'OZON', 2300), (17, 'WildBerries', 2400);
    END IF;
END $$;

SELECT 'phones' AS table_name, COUNT(*) AS rows FROM phones
UNION ALL SELECT 'characteristics', COUNT(*) FROM characteristics
UNION ALL SELECT 'shops', COUNT(*) FROM shops
UNION ALL SELECT 'orders', COUNT(*) FROM orders;
