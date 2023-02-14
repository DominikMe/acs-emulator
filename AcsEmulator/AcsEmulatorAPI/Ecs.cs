using System.Text;
using System.Text.Json;

namespace AcsEmulatorAPI
{
	public static class EcsService
	{
		public static void AddEcs(this WebApplication app)
		{
			const string trouterUrl = "wss://go.trouter.skype.com/v4/a"; //original wss://go.trouter.skype.com/v3/c"
																		 // trusted domains?

			app.MapGet("/ecs", () => JsonSerializer.Deserialize<dynamic>("""
				{
				  "AcsCallingSDK": {
				    "captions": {
				      "botMri": "28:8133db4c-c049-4346-9edd-273f164a9227",
				      "clientInfo": "ACS-Public",
				      "availableLanguages": [
				        "ar-ae",
				        "ar-sa",
				        "da-dk",
				        "de-de",
				        "en-au",
				        "en-ca",
				        "en-gb",
				        "en-in",
				        "en-nz",
				        "en-us",
				        "es-es",
				        "es-mx",
				        "fi-fi",
				        "fr-ca",
				        "fr-fr",
				        "hi-in",
				        "it-it",
				        "ja-jp",
				        "ko-kr",
				        "nb-no",
				        "nl-be",
				        "nl-nl",
				        "pl-pl",
				        "pt-br",
				        "ru-ru",
				        "sv-se",
				        "zh-cn",
				        "zh-hk"
				      ]
				    }
				  },
				  "AcsCallingSDKWeb": {
				    "calling": {
				      "eudb": {
				        "isEnabled": false
				      },
				      "mediaMetricsDeviceEventsEnabled": true,
				      "applyViewLimit": true,
				      "allowAccessRawMediaStream": true,
				      "removeLvsCheckOnCallStartAndCallAccept": true,
				      "deviceNotFunctioningMuted": false
				    },
				    "telemetry": {
				      "mediaStatsConfig": {
				        "enableLegacyMediaStats": true
				      },
				      "callStatsFlushTimeout": 5000
				    },
				    "environments": {
				      "android": {
				        "chrome": {
				          "minVersion": "105",
				          "isSupportedOnSdkVersion": true
				        }
				      },
				      "ios": {
				        "safari": {
				          "minVersion": "15.6",
				          "isSupportedOnSdkVersion": true
				        }
				      },
				      "mac": {
				        "chrome": {
				          "minVersion": "105",
				          "isSupportedOnSdkVersion": true
				        },
				        "safari": {
				          "minVersion": "15.6",
				          "isSupportedOnSdkVersion": true
				        },
				        "edgeanaheim": {
				          "minVersion": "105",
				          "isSupportedOnSdkVersion": true
				        },
				        "firefox": {
				          "minVersion": "105",
				          "isSupportedOnSdkVersion": true
				        }
				      },
				      "windows": {
				        "chrome": {
				          "minVersion": "105",
				          "isSupportedOnSdkVersion": true
				        },
				        "chromium": {
				          "minVersion": "108",
				          "isSupportedOnSdkVersion": true
				        },
				        "edgeanaheim": {
				          "minVersion": "105",
				          "isSupportedOnSdkVersion": true
				        },
				        "firefox": {
				          "minVersion": "105",
				          "isSupportedOnSdkVersion": true
				        }
				      },
				      "linux": {
				        "chrome": {
				          "minVersion": "105",
				          "isSupportedOnSdkVersion": true
				        },
				        "firefox": {
				          "minVersion": "105",
				          "isSupportedOnSdkVersion": true
				        }
				      }
				    },
				    "transcription": {
				      "acsBotId": "28:8133db4c-c049-4346-9edd-273f164a9227",
				      "teamsBotId": "",
				      "clientInfo": "Teams-Public",
				      "availableLanguages": [
				        "ar-ae",
				        "ar-sa",
				        "da-dk",
				        "de-de",
				        "en-au",
				        "en-ca",
				        "en-gb",
				        "en-in",
				        "en-nz",
				        "en-us",
				        "es-es",
				        "es-mx",
				        "fi-fi",
				        "fr-ca",
				        "fr-fr",
				        "hi-in",
				        "it-it",
				        "ja-jp",
				        "ko-kr",
				        "nb-no",
				        "nl-be",
				        "nl-nl",
				        "pl-pl",
				        "pt-br",
				        "ru-ru",
				        "sv-se",
				        "zh-cn",
				        "zh-hk"
				      ]
				    },
				    "captions": {
				      "botMri": "28:8133db4c-c049-4346-9edd-273f164a9227",
				      "clientInfo": "ACS-Public",
				      "availableLanguages": [
				        "ar-ae",
				        "ar-sa",
				        "da-dk",
				        "de-de",
				        "en-au",
				        "en-ca",
				        "en-gb",
				        "en-in",
				        "en-nz",
				        "en-us",
				        "es-es",
				        "es-mx",
				        "fi-fi",
				        "fr-ca",
				        "fr-fr",
				        "hi-in",
				        "it-it",
				        "ja-jp",
				        "ko-kr",
				        "nb-no",
				        "nl-be",
				        "nl-nl",
				        "pl-pl",
				        "pt-br",
				        "ru-ru",
				        "sv-se",
				        "zh-cn",
				        "zh-hk"
				      ]
				    },
				    "rendering": {
				      "remoteVideo": {
				        "createViewTimeout": 12000
				      }
				    }
				  },
				  "AsyncMediaClient": {
				    "use_emoticon_batch_add": true,
				    "storage_limits": {
				      "original": {
				        "size": 314573500,
				        "media_type": "generic_file"
				      },
				      "imgpsh": {
				        "size": 20971520,
				        "media_type": "generic_file",
				        "format": [
				          "jpeg",
				          "png",
				          "jpg"
				        ],
				        "width": 10000,
				        "height": 10000
				      },
				      "video": {
				        "size": 104857600,
				        "media_type": "generic_file"
				      },
				      "thumbnail": {
				        "size": 5242880,
				        "media_type": "generic_file"
				      },
				      "audio": {
				        "size": 20971520,
				        "media_type": "audio"
				      }
				    },
				    "use_download_multi_queue": true,
				    "download_categories": {
				      "number_of_parallel_downloads": 5,
				      "explicit_user_action": {
				        "priority": 30,
				        "min_slots": 1,
				        "max_slots": 3,
				        "inverted": false
				      },
				      "ui_rendering": {
				        "priority": 20,
				        "min_slots": 1,
				        "max_slots": 3,
				        "inverted": false
				      },
				      "preload": {
				        "priority": 10,
				        "min_slots": 0,
				        "max_slots": 2,
				        "inverted": false
				      },
				      "default": {
				        "priority": 10,
				        "min_slots": 0,
				        "max_slots": 2,
				        "inverted": false
				      }
				    },
				    "media_params": {
				      "SWIFT.1": {
				        "category": {
				          "thumbnail": 3
				        }
				      },
				      "File.1": {
				        "telemetry_enabled": true,
				        "template": "https://login.skype.com/login/sso?go=xmmfallback&docid=%1",
				        "create_local_message": true,
				        "malware_scan_needed": true,
				        "expiration_period": 30,
				        "required_content_ids": [
				          "original"
				        ]
				      },
				      "Video.1=Message.1": {
				        "telemetry_enabled": true,
				        "description": "Video Message",
				        "title": "Video Message",
				        "template": "https://login.skype.com/login/sso?go=xmmfallback&vim=%1",
				        "required_content_ids": [
				          "video",
				          "thumbnail"
				        ],
				        "malware_scan_needed": false,
				        "expiration_period": 3650,
				        "create_local_message": true
				      },
				      "Audio.1=Message.1": {
				        "telemetry_enabled": true,
				        "title": "Audio Message",
				        "description": "Audio Message",
				        "template": "https://login.skype.com/login/sso?go=xmmfallback&am=%1",
				        "required_content_ids": [
				          "audio"
				        ],
				        "malware_scan_needed": false,
				        "create_local_message": true
				      },
				      "Audio.1": {
				        "template": "https://login.skype.com/login/sso?go=mediamessage&amp;%1",
				        "title": "Some title",
				        "description": "Audio Message",
				        "layoutType": "icon"
				      },
				      "Video.1=Flik.1": {
				        "title": "",
				        "description": "Moji",
				        "template": "https://login.skype.com/login/sso?go=xmmfallback&%1"
				      },
				      "Picture.1": {
				        "create_local_message": true,
				        "template": "https://login.skype.com/login/sso?go=xmmfallback?pic=%1",
				        "required_content_ids": [
				          "imgpsh"
				        ]
				      }
				    },
				    "url_preview_service_url": "https://urlp.asm.skype.com/v1/url/info?url=",
				    "pes_config": "https://static-asm.secure.skypeassets.com/pes/v01/configs/b1e3e5b12e5b43d7bf81069cf5b011a0",
				    "telemetry_enabled": false,
				    "cache_emoticon_assets": true,
				    "cache": {
				      "emoticon_cache_size": 500000000,
				      "media_cache_size": 300000000
				    },
				    "trusted_domains": "go.skype.com;login.skype.com;*.api.skype.com;*.asm.skype.com;*.asm.skype.net;*.secure.skypeassets.com;*.secure.skypeassets.net;secure.skypeassets.com;secure.skypeassets.net;latest-webclient.skype.com;web.skype.com;apps.skypeassets.com",
				    "auth_trusted_domains": "go.skype.com;login.skype.com;*.api.skype.com;*.asm.skype.com;*.asm.skype.net;latest-webclient.skype.com;web.skype.com",
				    "provisioned": true,
				    "media_messaging_enabled": true,
				    "legacy_link_template": "<a href=\"https://api.asm.skype.com/s/i?%1\">https://api.asm.skype.com/s/i?%1</a>",
				    "max_sharings_at_once": 1,
				    "url_preview_enabled": true,
				    "url_preview_queue_shared": true,
				    "storage_transform_rules": [],
				    "distribution_transform_rules": [
				      {
				        "target": "original",
				        "sources": [
				          {
				            "type": "content",
				            "name": "original"
				          }
				        ],
				        "transform_params": {
				          "media_type": "generic_file",
				          "actions": null
				        }
				      },
				      {
				        "target": "video",
				        "sources": [
				          {
				            "type": "content",
				            "name": "video"
				          }
				        ],
				        "transform_params": {
				          "media_type": "video",
				          "format": "mp4",
				          "actions": null
				        }
				      },
				      {
				        "target": "audio",
				        "sources": [
				          {
				            "type": "content",
				            "name": "audio"
				          }
				        ],
				        "transform_params": {
				          "media_type": "audio",
				          "format": "mp4",
				          "actions": null
				        }
				      },
				      {
				        "target": "thumbnail",
				        "sources": [
				          {
				            "type": "content",
				            "name": "thumbnail"
				          }
				        ],
				        "transform_params": {
				          "media_type": "image",
				          "format": "jpeg",
				          "actions": null
				        }
				      },
				      {
				        "target": "imgpsh_fullsize",
				        "sources": [
				          {
				            "type": "content",
				            "name": "imgpsh"
				          }
				        ],
				        "transform_params": {
				          "media_type": "image",
				          "action": null
				        }
				      },
				      {
				        "target": "avatar_fullsize",
				        "sources": [
				          {
				            "type": "content",
				            "name": "avatar"
				          }
				        ],
				        "transform_params": {
				          "media_type": "image",
				          "format": "jpeg",
				          "actions": [
				            {
				              "action": {
				                "scale_type": "fit",
				                "width": 800,
				                "height": 800
				              }
				            }
				          ]
				        }
				      },
				      {
				        "target": "imgpsh_mobile_save",
				        "sources": [
				          {
				            "type": "content",
				            "name": "imgpsh"
				          }
				        ],
				        "transform_params": {
				          "media_type": "image",
				          "format": "jpeg",
				          "actions": [
				            {
				              "action": {
				                "scale_type": "fit",
				                "width": 2048,
				                "height": 2048
				              }
				            }
				          ]
				        }
				      },
				      {
				        "target": "imgpsh_thumbnail_wp",
				        "sources": [
				          {
				            "type": "content",
				            "name": "imgpsh"
				          },
				          {
				            "type": "profile",
				            "name": "imgo"
				          }
				        ],
				        "transform_params": {
				          "media_type": "image",
				          "format": "jpeg",
				          "actions": [
				            {
				              "action": {
				                "scale_type": "fill",
				                "width": 216,
				                "height": 216
				              }
				            }
				          ]
				        }
				      },
				      {
				        "target": "imgt1",
				        "sources": [
				          {
				            "type": "content",
				            "name": "imgpsh"
				          },
				          {
				            "type": "profile",
				            "name": "imgo"
				          }
				        ],
				        "transform_params": {
				          "media_type": "image",
				          "format": "jpeg",
				          "actions": [
				            {
				              "action": {
				                "scale_type": "fill",
				                "width": 348,
				                "height": 340
				              }
				            }
				          ]
				        }
				      },
				      {
				        "target": "imgt2",
				        "sources": [
				          {
				            "type": "content",
				            "name": "imgpsh"
				          },
				          {
				            "type": "profile",
				            "name": "imgo"
				          }
				        ],
				        "transform_params": {
				          "media_type": "image",
				          "format": "jpeg",
				          "actions": [
				            {
				              "predicate": {
				                "aspect": "square",
				                "epsilon": "0.1"
				              },
				              "action": {
				                "scale_type": "fill",
				                "width": 150,
				                "height": 150
				              }
				            },
				            {
				              "predicate": {
				                "aspect": "horizontal",
				                "epsilon": "0.1"
				              },
				              "action": {
				                "scale_type": "fill",
				                "width": 210,
				                "height": 150
				              }
				            },
				            {
				              "predicate": {
				                "aspect": "vertical",
				                "epsilon": "0.1"
				              },
				              "action": {
				                "scale_type": "fill",
				                "width": 150,
				                "height": 210
				              }
				            }
				          ]
				        }
				      },
				      {
				        "target": "imgpsh_thumbnail_win",
				        "sources": [
				          {
				            "type": "content",
				            "name": "imgpsh"
				          },
				          {
				            "type": "profile",
				            "name": "imgpsh_fullsize"
				          },
				          {
				            "type": "profile",
				            "name": "imgo"
				          }
				        ],
				        "transform_params": {
				          "media_type": "image",
				          "format": "jpeg",
				          "actions": [
				            {
				              "predicate": {
				                "aspect": "square",
				                "epsilon": "0.1"
				              },
				              "action": {
				                "scale_type": "fill",
				                "width": 164,
				                "height": 164
				              }
				            },
				            {
				              "predicate": {
				                "aspect": "horizontal",
				                "epsilon": "0.1"
				              },
				              "action": {
				                "scale_type": "fill",
				                "width": 230,
				                "height": 164
				              }
				            },
				            {
				              "predicate": {
				                "aspect": "vertical",
				                "epsilon": "0.1"
				              },
				              "action": {
				                "scale_type": "fill",
				                "width": 164,
				                "height": 230
				              }
				            }
				          ]
				        }
				      },
				      {
				        "target": "imgo",
				        "sources": [
				          {
				            "type": "content",
				            "name": "imgpsh"
				          }
				        ],
				        "transform_params": {
				          "media_type": "image",
				          "format": "jpeg",
				          "actions": [
				            {
				              "action": {
				                "scale_type": "fit",
				                "width": 800,
				                "height": 800
				              }
				            }
				          ]
				        }
				      }
				    ],
				    "distribution_presentation_pool_size": 0
				  },
				  "ClientLogin": {
				    "url": "https://clientlogin.cdn.skype.com/cdn/6.0.1/release/index.html",
				    "msaRegistrationFlow": "phone2",
				    "ifExistsVersion": "2.0",
				    "msaFlight": "hsu,ReservedFlight33,ReservedFlight67",
				    "msaPsi": "skype"
				  },
				  "ConsumerEntitlement": {
				    "SCE": {
				      "UserServices": {
				        "Client": {
				          "Features": {
				            "NewUcuxCallActionEnabled": true,
				            "UIEnabled": true,
				            "BackendEnabled": true,
				            "AdvancedPullingEnabled": true,
				            "RateIntegrationEnabled": true,
				            "ReactivationEnabled": false,
				            "DialpadConfig": {
				              "Old": true,
				              "V10": false,
				              "V20": false
				            },
				            "DarkerDialerBarEnabled": true
				          },
				          "Experiments": {
				            "SkypeToPhoneCard": "newCta",
				            "SkypeToPhoneInProfile": true
				          },
				          "Service": {
				            "Host": "consumer.entitlement.skype.com",
				            "RetryInterval": [
				              {
				                "Codes": [
				                  "40401",
				                  "40402",
				                  "40162",
				                  "40163"
				                ],
				                "Pattern": [
				                  5000,
				                  10000,
				                  20000,
				                  30000,
				                  60000
				                ]
				              },
				              {
				                "Codes": [
				                  "50310",
				                  "IOException"
				                ],
				                "Pattern": [
				                  1000,
				                  2000,
				                  4000,
				                  8000,
				                  16000
				                ]
				              }
				            ],
				            "RetryLimit": 5
				          }
				        },
				        "ServiceGroups": {
				          "Credit": [
				            "pstn"
				          ],
				          "Calling": [
				            "plan",
				            "package",
				            "minute_plan"
				          ],
				          "OnlineNumbers": [
				            "skypein",
				            "skypein2"
				          ],
				          "PersonalExpressions": [
				            "moiji"
				          ]
				        }
				      },
				      "Dialpad": {
				        "ContactsSearch": {
				          "T9SearchEnabled": true,
				          "ExecutionDelay": 280
				        },
				        "EmergencyCall": {
				          "allowedCountries": [
				            "gb",
				            "fi",
				            "au",
				            "dk"
				          ]
				        },
				        "CountryCodeToCountryDefault": {
				          "1": "us",
				          "7": "ru",
				          "44": "gb",
				          "47": "no",
				          "61": "au",
				          "64": "nz",
				          "262": "re",
				          "358": "fi",
				          "500": "fk",
				          "590": "gp"
				        }
				      }
				    }
				  },
				  "ConsumerEntitlementCampaigns": {
				    "SCE": {
				      "Campaigns": {
				        "Service": {
				          "Host": "campaign.consumer.entitlement.skype.com",
				          "RetryInterval": "",
				          "RetryLimit": ""
				        },
				        "Client": {
				          "Campaigns": "[]"
				        }
				      }
				    }
				  },
				  "CQF": {
				    "Tenant": "Media Agent Prod",
				    "TenantToken": "eab9f6f272f94c0380e89c46324ede7a-34dc0748-fb55-4485-b82c-ea7753fb9887-7371",
				    "CqfExperience": 12
				  },
				  "DebugabilitySquad": {
				    "enableDiagnosticTools": true,
				    "blacklist": [
				      "TestID"
				    ],
				    "userBlacklist": [
				      "blacklisted_bad_user",
				      "live:.cid.3b6eb539c0d93598"
				    ]
				  },
				  "ECS": {},
				  "ECS_Scorecards_Test": {},
				  "ECSCONFIG": {
				    "TelemetryEnabled": {
				      "fetch_config": true,
				      "set_config": true,
				      "suspend_resume_fetch": false
				    },
				    "login_config_fetch_delay": 200,
				    "cache_save_delay": 10000,
				    "disable_fetch_in_background": true,
				    "disable_fetch_in_call": true
				  },
				  "JennyTest2": {},
				  "Join": {
				    "useFingerprintForJoinLink": false,
				    "guestFlow": {
				      "enabled": true,
				      "useLatestApiForGuestCreation": false
				    },
				    "meetings": {
				      "apiHost": "https://api.join.skype.com",
				      "useMeetingsApiForJoinUrlGeneration": true
				    }
				  },
				  "JoinLauncher": {
				    "cdn": "//az801095.vo.msecnd.net/dev/JoinLauncher",
				    "version": "v1"
				  },
				  "LearningAppMobile": {
				    "mobile": {
				      "isCatalogPermissionEnabled": true,
				      "inAppBrowserProviders": "LINKED_IN,ELD,CORNER_STONE,COURSERA,CUSTOM_SOURCE,ED_CAST,ED_X,GO_1,INFOSEC,JBA,OPEN_SESAME,PLURALSIGHT,SABA,SKILLSOFT,SUCCESS_FACTORS,TENANT_SPECIFIC_SKILLSOFT,UDEMY,UNSPECIFIED,WORKDAY",
				      "isNewSearchExperienceEnabled": true,
				      "isRequestTimeoutEnabled": true,
				      "isInAppBrowserEnabled": true,
				      "isDetailsViewQueryDecouplingEnabled": true,
				      "isShareEnabled": true,
				      "isAssignmentsEnabled": true,
				      "isNewExperienceEnabled": true,
				      "isPullToRefreshEnabled": true,
				      "isUserLicenseCheckEnabled": true,
				      "isMyLearningFREEnabled": true,
				      "isFeaturedContentEnabled": true,
				      "isRecentlyViewedEnabled": true,
				      "isBookmarkEnabled": true,
				      "isViewsEnabled": true,
				      "isRecommendAndManageEnabled": true,
				      "isFooterEnabled": true,
				      "isTrendingSectionEnabled": true,
				      "isSeeMoreEnabled": true,
				      "isCopyLinkEnabled": true,
				      "isContextMenuEnabled": true
				    }
				  },
				  "MDN_MIDDLELANE_TEAMS": {
				    "liveStream": {
				      "sendInitialTelemetryAfterMs": 60000,
				      "sendSnapshotTelemetry": true
				    }
				  },
				  "MDN_TRAP": {
				    "Service": {
				      "url": "https://edge.skype.com/trap",
				      "tokenUrl": "https://edge.skype.com/trap/tokens",
				      "s2sTokenUrl": "https://trap.skype.com:444/acs-token",
				      "disabled": false
				    },
				    "Relay": {
				      "Skype": {
				        "addresses": [
				          "20.202.255.225"
				        ],
				        "fqdns": [
				          "msturn.azure.com"
				        ],
				        "tcpPort": 443,
				        "udpPort": 3478
				      },
				      "Turn": {
				        "addresses": [
				          "20.202.255.225"
				        ],
				        "fqdns": [
				          "turn.azure.com"
				        ],
				        "tcpPort": 443,
				        "udpPort": 3478,
				        "url": ""
				      },
				      "addresses": [
				        "127.0.0.1"
				      ],
				      "tcpPort": 443,
				      "udpPort": 3478,
				      "Lync": {
				        "addresses": [
				          "127.0.0.1"
				        ],
				        "tcpPort": 443,
				        "udpPort": 3478
				      }
				    },
				    "Http": {
				      "connectionTimeout": 30,
				      "requestTimeout": 60
				    },
				    "Token": {
				      "earlyRefreshMinutes": 1080,
				      "earlyRefreshPercentage": 25
				    }
				  },
				  "MDNRAP": {
				    "DedicatedRelay": {
				      "Fqdn": "dr.skype-cr.akadns.net",
				      "PreLoadBalancingFqdns": 8,
				      "FBPortsEnabled": 1,
				      "Enabled": 1,
				      "Ports": "50000,50001,50002,50003,50004,50005,50006,50007",
				      "BandwidthBytesPerSecond": 64000,
				      "UseFrequencyPercentage": 100,
				      "Priority": 34,
				      "DnsResolvTimeoutMsec": 2000,
				      "Invalid": "127.0.0.1"
				    },
				    "Session": {
				      "PrivateSkypeMode": true,
				      "AcceleratePrivateSkypeMode": true,
				      "EnableLockOnDedicatedRelay": 1,
				      "SendHS2UponConnectingToDR": 1,
				      "EuthanizeRelaysOnEarlyHS2": 1,
				      "XAsymmetricStreamDetection_MDN835": 1,
				      "ChannelCheckTimeoutMsec": 4000,
				      "ChannelCheckTriggerGapMsec": 60000
				    }
				  },
				  "MediaAgent": {
				    "MultiStream": {
				      "VideoIndexMin": 9,
				      "VideoIndexMax": 9
				    }
				  },
				  "MicrosoftTeamApprovals": {
				    "AdditionalFilters": true,
				    "AdditionalSourceFilter": false,
				    "EnableExpandRequestHistory": "Dev,Int,Ppe,Prod",
				    "ESignUploadFileFromOneDriveEnabled": true,
				    "MaxNumberOfApprovers": 50,
				    "DocusignEnhancedWebhook": true,
				    "ESignCreateIOS": true,
				    "ESignCreateAndroid": true,
				    "InTemplatePromotion": false,
				    "TeamTagEnabled": true,
				    "RestoreGroupEnabled": true,
				    "PriorityColumnEnabled": true,
				    "AdobeStageViewEnabled": true,
				    "DocusignStageViewEnabled": true,
				    "ESignListIOS": true,
				    "ESignListAndroid": true,
				    "ESignDetailsIOS": true,
				    "ESignDetailsAndroid": true,
				    "DataExportEnabled": true,
				    "DataExportStatusPollInterval": 15000,
				    "DataExportCoachMarkEnabled": true,
				    "ViewerPermissionEnabled": false,
				    "AddViewerOnCreateEnabled": false,
				    "UseCacheForViewerPermissions": true,
				    "TTLOfViewerRoleCache": "2",
				    "GroupApprovalEnabled": true,
				    "GroupApprovalReassignEnabled": false,
				    "GroupApprovalNudgeEnabled": false,
				    "UseHpaToAccessUserShards": true,
				    "DocusignWebhookEnabled": true,
				    "FetchResourceTokenFromServiceForHosts": "",
				    "AdminGroupEnabled": true,
				    "UseSniForSubstrate": false,
				    "NewTemplateManagementButtonEnabled": true,
				    "TemplateManagementButtonCoachMarkValue": "TemplateListScopeCoachMark_20211031",
				    "RedisHealthCheckEnabled": true,
				    "CosmosDBHealthCheckEnabled": true,
				    "AdobeRefreshTokenFlowEnabled": true,
				    "DocusignRefreshTokenFlowEnabled": true,
				    "ShowNewRequestPageToggleButton": true,
				    "RequestPageVersionByDefault": 1,
				    "RequestPageVersionIOS": 2,
				    "RequestPageVersionAndroid": 2,
				    "UseHpaToAccessGroupShards": true,
				    "OnlineWorkflowSchemaVersion": "v2.0",
				    "DocusignEnabled": true,
				    "DocusignEnabledIOS": false,
				    "DocusignEnabledAndroid": false,
				    "AdobeSignTemplates": true,
				    "AdobeEnabled": true,
				    "AdobeEnabledIOS": false,
				    "AdobeEnabledAndroid": false,
				    "AdobeViewDetailsEnabled": true,
				    "PersonalAppV2": true,
				    "AdobeSignSearchAPI": true,
				    "AdobeSigninPage": true,
				    "ReassignEnabled": true,
				    "ListTeamTemplateInstancesBatchEnabled": true,
				    "ListTeamTemplateInstanecsBatchSize": 10,
				    "ListTeamTemplateInstancesBatchRetry": 3,
				    "NudgeApproversEnabled": true,
				    "CreateDiffEnvEnabled": true,
				    "CreateDiffEnvEnablediOS": true,
				    "CreateDiffEnvEnabledAndroid": true,
				    "ShareLinkEnabled": true,
				    "SharePointPickerEnabled": true,
				    "SharePointPickerEnabledForVanityDomain": true,
				    "MarkdownEnabled": true,
				    "RBAC_5ApproversOnly": "Dev,Int,Ppe,Prod,Gcc",
				    "RoleBasedAdaptiveCards": "Dev,Int,Ppe,Prod,Gcc",
				    "RBAC_NoOfApprovers": "60",
				    "ShowUserFREButton": true,
				    "ShowUserFREButtonAndroid": true,
				    "ShowUserFREButtonIOS": true,
				    "NotificationAPIv2": "Dev,Int,Ppe,Prod,Gcc",
				    "ListEnvironmentsFlowAPICall": "Dev,Int,Ppe,Prod,Gcc",
				    "EnvironmentPicker": true,
				    "EnvironmentPickerIOS": true,
				    "EnvironmentPickerAndroid": true,
				    "PeoplePickerRetrySearchThreshold": 5,
				    "UITemplateRingEnv": "prod,ppe,int,dev",
				    "MobileEntryMenuEnabledIOS": true,
				    "MobileEntryMenuEnabledAndroid": true,
				    "PeoplePickerMezzoAPI": true,
				    "UI_ShowAppHeader": true,
				    "ProvisioningAPIEnabledEnvs": "Dev,Int,Ppe,Prod,Gcc",
				    "TemplateEnabled": true,
				    "EnableTemplateFileAttachment": true,
				    "TemplatePreviewEnabled": true,
				    "AdaptiveCardV2": true,
				    "CustomResponsesEnabled": true,
				    "CustomResponsesEnabledIOS": true,
				    "CustomResponsesEnabledAndroid": true,
				    "MaxCustomReponseOptions": 2,
				    "RequiredCustomResponseOptions": 1,
				    "ChannelPeopleResultsPageSize": 1000,
				    "PeoplePickerV2": true,
				    "FileUploadEnabled": true,
				    "FileUploadEnabledIOS": true,
				    "FileUploadEnabledAndroid": true,
				    "FileUploadAcceptedTypes": "",
				    "OpenUploadedFilesIOS": true,
				    "OpenUploadedFilesAndroid": true
				  },
				  "MicrosoftTeamLearning": {
				    "isStandAloneMVPEnabled": false,
				    "IsStopMovingOfSeededTenantToSubstrateEnabled": false,
				    "scheduledJobToTriggerCreateSubstrateConnectionManagerJob": false,
				    "maxNumberOfTenantsAllowedToBeProcessedForSchemaUpgrade": 0,
				    "IsSubstrateIngestionScheduledJobEnabled": false,
				    "IsLicenseFetchFromProfileEnabled": false,
				    "IsLRSReplayFromATSEnabled": false,
				    "IsSFLRSATSSyncEnabled": false,
				    "MoveSPIngestionToLMSPipeline": false,
				    "AssignmentReminderDayList": "",
				    "enableDualWrite": false,
				    "enableLMSMigrationScheduledJob": false,
				    "switchReadsToLMSConfiguration": false,
				    "SFUserMappingRules": {
				      "IgnoreLeadingZeroes": false,
				      "LeadingPrefixesToIgnore": null
				    },
				    "IsPGPKeyPairValidationEnabledForSF": true,
				    "IsUserGroupMembershipsCachingEnabled": true,
				    "IsRefreshUserGroupsOnDemandEnabled": false,
				    "IsNewCosmosInstanceForNewTenantsEnabled": false,
				    "CurrentCosmosInstanceIdForNewTenants": "",
				    "IsCourseActivityGraphAPIEnabled": false,
				    "DeletionQueueName": "LMSDeletionQueue",
				    "IsAdminConfigKeyRotationJobEnabled": true,
				    "MaxIngestionInProgressDurationInMinutes": 2160,
				    "isLearningPathWithSectionsEnabled": false,
				    "isNotificationBatchingEnabled": true,
				    "IsGenerativeThumbnailV2Enabled": true,
				    "isMsLearnPlayerEnabled": false,
				    "IsPopulatePermissionsFlagScheduledJobEnabled": true,
				    "isSpecialCharacterAllowedInSearch": true,
				    "LinkedInAPIPackagingVersion": 1,
				    "IsTenantEnabledForAzureConnectionManagerJob": true,
				    "MaxTenantsProcessingAllowedPerRunForAzureConnectionManagerJob": 3600,
				    "MaxAzureIngestionOnDemandMessageCount": 1000,
				    "AzureIndexMaxErrorDurationInMinutes": 300,
				    "AzureIndexMaxDurationBeforeIngestionInMinutes": 225,
				    "isSuccessFactorsInAppContentPlayEnabled": true,
				    "IsFilterOnAssignmentsByDateDisabled": false,
				    "IsRegenerativeThumbnailV2Enabled": false,
				    "IsTestConfigEnabled": true,
				    "isGraphCAEEnabled": false,
				    "isLWSSourceIngestionOnDemandJobEnabled": false,
				    "isFatHeaderRemoveEnabled": true,
				    "providerThrottlingEnabledForGraphAPI": true,
				    "IsUserFlightedForScoringProfiles": true,
				    "isLearningPathEnabled": false,
				    "IsSoftLinkEnabled": false,
				    "IsSSOEnabledForComposeExtension": false,
				    "IsEnrichLearningObjectForAppTokenFlowEnabled": false,
				    "IsWorkdayThumbnailImagesFeatureEnabled": false,
				    "IsTriggerThumbnailImagesRefreshScheduledJobEnabled": true,
				    "IsLearningPathEnabled": false,
				    "IsLRSUserRecommendationDeleteEnabled": false,
				    "IsUsageOfLOIDInGraphApiEnabled": true,
				    "RegionalConcurrencyValueForNotifications": 10,
				    "GoLocalConcurrencyValueForNotifications": 2,
				    "EndDateForNotificationFixJob": "12/31/2027",
				    "BatchSizeForNotifications": 1000,
				    "isManageProvidersEnabled": true,
				    "LowFrictionTrialDurationInDays": 60,
				    "isBaseCatalogPermissionsEnabled": true,
				    "IsTenantFlightedForScoringProfiles": false,
				    "IsSchedulerFixJobDeleteEnabled": false,
				    "IsNewTelemetryClassificationEnabled": true,
				    "IsSPLinkItemSupportEnabled": true,
				    "IsUsageOfLearningSourceIdInCognitiveSearchServiceEnabled": false,
				    "TrustedPartnerAppsForApiOnboarding": [
				      "b21d935e-2486-479e-a9f9-0472e42ad654",
				      "0a5ec315-817e-4f80-a07d-b8d992322b8d",
				      "bca1a7df-eaa5-4d78-b0fb-0a43ec711937",
				      "9219f5d1-a777-4035-bd0c-a5e236d3ad4e",
				      "a4d9bb09-84b9-4cef-a54d-b8a0ac5edc83",
				      "d93c3f28-d48f-4ba3-83af-5c36d8037a7f",
				      "00000003-0000-0000-c000-000000000000",
				      "395a47ef-fe34-4879-b50c-2ad830a1bab1",
				      "fc41ed7e-c3bd-4b03-ae89-f663cdc452b1",
				      "8d23a791-af0d-4da4-808b-22223591bf23",
				      "ec2b6b75-aacf-4662-bbbf-6a91394ce2e5",
				      "7d2bccb4-d279-4800-84dd-15caed283b5d",
				      "2caa9aa4-deaf-4c25-8a45-2542cbd78d98",
				      "2c1a896c-ac3f-48ef-b627-1b1c7953c9b8",
				      "4191bd61-f637-4e6b-ad23-2ef5740bf083",
				      "9605de81-d9c7-4a2c-a938-e268b17c48e4",
				      "adb53b4f-b05f-4dcb-a2e1-9111380568c3",
				      "83a34322-2783-465c-9e92-861fad0eb150",
				      "501297ff-affd-41da-9def-144ca05d9438",
				      "c3902fe2-1cd3-4421-a55c-a469fa4042be",
				      "cede7d51-9596-43af-a960-5aafbdc1134e",
				      "c40da342-5325-4be4-89cb-51a16fbbf9fc",
				      "6f9dbc98-9bc6-4861-8fca-972a33afabb7",
				      "632edb7b-675b-4d6c-b8d5-ef4f1f8b6dc3",
				      "f207d88d-7cc5-4d0a-a9c4-27cac6ca22d6",
				      "5ef9b282-3233-40ac-bea3-0efff231b870",
				      "629c93c9-a1e1-4580-86d3-1ffa025140c0",
				      "b3265c71-fd21-40a7-a7ee-0f86b5d1a19b",
				      "de8bc8b5-d9f9-48b1-a8ad-b748da725064",
				      "104690b0-814b-4068-a5bf-6b1211e12cf5",
				      "81938eb5-8e18-4cda-80f8-1ab58647034e"
				    ],
				    "IsUsageOfLearningSourceIdInLearningSourceRepositoryEnabled": false,
				    "isLiLHubFirstPartySSOEnabled": false,
				    "scheduledJobAllowedTenants": [],
				    "isScheduledJobEnabledForAllTenants": true,
				    "EnableValidationOnCatalogAPIs": true,
				    "IsTenantFlightedForGoLocalDogfood": false,
				    "PerformAppValidationOnCatalogAPIs": false,
				    "UseAzureIndexOverSubstrate": true,
				    "IsLASCosmosDBProviderV2Enabled": false,
				    "IsLMSCosmosDBProviderV2Enabled": false,
				    "IsLearningAppCosmosDBProviderV2Enabled": false,
				    "IsGlobalCosmosDBProviderV2Enabled": false,
				    "IsSFUserMappingSyncNewCodePathEnabled": true,
				    "IsCatalogPermissionsEnabled": true,
				    "UseAzuriteEmulatorDevTesting": false,
				    "AdminConfigEncryptionKeyExpirationInDays": 72,
				    "TenantSubscriptionId": [
				      "22d5e26e-0c2f-4cf1-9aab-be3b067e601f",
				      "50ffb821-c546-41a7-ae1f-0377a25c9bbf",
				      "d4ac35a3-1436-47a3-9da8-68e0b8a948c9"
				    ],
				    "MaxIntervalForTriggerMigrationOfLMSLOIdsInSeconds": 2,
				    "MaxIntervalForLockTriggerMigrationOfLMSLOIdsInMinutes": 5,
				    "LearningSourceInconsistencyFixJobIntervalInMinutes": 360,
				    "SuccessFactorsUrlValidationRegex": "^[a-zA-Z0-9!*'()+$,_.~-]{1,256}\\.(sapsf|successfactors|plateau)\\.(com|eu|cn)$",
				    "scheduledJobToDeleteExpiredMetadata": false,
				    "scheduledJobToTriggerIngestion": false,
				    "scheduledJobToTriggerDeletionLearningSource": false,
				    "scheduledJobToTriggerLIRecomputation": false,
				    "scheduledJobToTriggerProcessingJob": false,
				    "scheduledJobToTriggerFetchJob": false,
				    "scheduledJobToTriggerLicenseCheck": false,
				    "scheduledJobToTriggerSourceDeletionJob": false,
				    "scheduledJobToTriggerLearningSourceIngestion": false,
				    "scheduledJobToTriggerCleanupConnectionManagerJob": false,
				    "ScheduledJobToTriggerNotifications": false,
				    "scheduledJobToTriggerSCIngestion": false,
				    "scheduledJobToTriggerSCMSITIngestion": false,
				    "scheduledJobToTriggerAzureConnectionManager": false,
				    "scheduledJobToTriggerAzureIngestion": false,
				    "scheduledJobToTriggerCreateConnectionManagerJob": false,
				    "scheduledJobToTriggerM365IntegrationJob": false,
				    "scheduledJobFixNotificationCreateDate": false,
				    "ScheduledJobToSendNotifications": false,
				    "scheduledJobToTriggerGlobalSourcesFetchJob": false,
				    "IsFixAddScaleScopeIdInTenantMetatdataScheduledJobEnabled": false,
				    "IsSFKeyProcessingEnabled ": true,
				    "IsSupportForMultipleProvidersOfSameSourceTypeEnabled": false,
				    "IsSPMetadataSupportEnabled": true,
				    "isFetchProviderOnDemandJobEnabled": true,
				    "isSourceDeletionOnDemandJobEnabled": true,
				    "isProcessLMSDataOnDemandJobEnabled": true,
				    "isTriggerSourceDeletionOnDemandJobEnabled": true,
				    "isUserDashboardPerfImprovementEnabled": true,
				    "IsAccessControlPermissionEnabledForSharePoint": true,
				    "isBackNavigationEnabled": true,
				    "IsLMSLASDbInconsistentFixJobEnabled": false,
				    "IsLMSLASDbInconsistentFixSchedulerEnabled": false,
				    "DemoTenantPremiumEnabled": false,
				    "isELDLearningPlayerEnabled": true,
				    "IsSFProgramSyncEnabled": true,
				    "GetSharePointM365PermissionSupportDate": "2018-04-25T00:00:00+00:00",
				    "isNewAdminTabEnabled": true,
				    "isRecommendationLRSMigrationEnabled": true,
				    "IsRegenerativeThumbnailEnabled": true,
				    "isInlineShareEnabled": true,
				    "isNotificationJobMigrationEnabled": true,
				    "isGenerativeThumbnailEnabled": true,
				    "IsSvg2PngConversionSkipEnabled": true,
				    "isDetailsViewQueryDecouplingEnabled": true,
				    "MultiShardMSITSubstrateShardNames": [
				      "SUBSTRATEMULTISHARDMSIT_LEARNINGAPPCONNECTORV9S1",
				      "SUBSTRATEMULTISHARDMSIT_LEARNINGAPPCONNECTORV9S2",
				      "SUBSTRATEMULTISHARDMSIT_LEARNINGAPPCONNECTORV9S3",
				      "SUBSTRATEMULTISHARDMSIT_LEARNINGAPPCONNECTORV9S4",
				      "SUBSTRATEMULTISHARDMSIT_LEARNINGAPPCONNECTORV9S5",
				      "SUBSTRATEMULTISHARDMSIT_LEARNINGAPPCONNECTORV9S6",
				      "SUBSTRATEMULTISHARDMSIT_LEARNINGAPPCONNECTORV9S7",
				      "SUBSTRATEMULTISHARDMSIT_LEARNINGAPPCONNECTORV9S8",
				      "SUBSTRATEMULTISHARDMSIT_LEARNINGAPPCONNECTORV9S9"
				    ],
				    "isLearningObjectRatingEnabled": true,
				    "isRatingEnabled": true,
				    "IsMultiShardSchemaMigrationJobEnabled": false,
				    "FetchDataFromMSITAzureIndex": true,
				    "IsMSFTMultiShardCreationJobEnabled": false,
				    "UnprocessedTenantListToMigrate": [
				      "a1ec00fa-dd64-4612-8fb4-9ad0da96ff62"
				    ],
				    "IsTenantEnabledForTFMigration": true,
				    "IsComposeExensionDefaultContentEnabled": true,
				    "CachingGetLearningObjectsByInterestsEnabled": true,
				    "IsTaskFabricMigrationJobEnabled": true,
				    "EnableScormContent": true,
				    "RemoveLicenseFromBootCriticalPath": true,
				    "IsLRSRecommendationNotificationEnabled": true,
				    "IsRecommendationMigrationComplete": true,
				    "IsBringYourOwnContentEnabled": true,
				    "IsProviderCatalogDeletionEnabled": true,
				    "IsTaskFabricDataMigrationSchedulerEnabled": true,
				    "IsLinkUnfurlEnabled": true,
				    "EnableDetailsViewExpFromTenantDB": false,
				    "isSwitchToProviderIdForAssignmentEnabled": true,
				    "isSwitchToProviderIdForCourseEnabled": true,
				    "isBYOCAddSharePointContentEnabled": true,
				    "DogfoodRoutingSettings": [
				      {
				        "GeoName": "NAM",
				        "DCSettings": [
				          {
				            "DCName": "WUS2",
				            "IsEnabled": true
				          },
				          {
				            "DCName": "EUS",
				            "IsEnabled": true
				          }
				        ]
				      },
				      {
				        "GeoName": "EMEA",
				        "DCSettings": [
				          {
				            "DCName": "NEU",
				            "IsEnabled": false
				          },
				          {
				            "DCName": "WEU",
				            "IsEnabled": false
				          }
				        ]
				      }
				    ],
				    "ShouldRouteRequestToDogfoodCluster": false,
				    "isErrorCodeAddedToDetailsViewInClient": true,
				    "isM365IntegrationJobEnabled": true,
				    "isM365IntegrationEnabled": true,
				    "isCarouselExperienceEnabled": true,
				    "isLinkUnfurlingEnabled": true,
				    "isSubscriptionLockUXEnabled": true,
				    "isSubscriptionIconLogicEnabledFor3P": false,
				    "isSubscriptionIconLogicEnabledForLMS": false,
				    "isLmsRecommendationEnabled": true,
				    "enabledLagroSources": [
				      "Skillsoft"
				    ],
				    "enableAdminConfigFromCosmos": true,
				    "MaxNumberOfSharepointItemsToIngest": 5000,
				    "MaxNumberOfSharepointFolderLevelsToCrawl": 5,
				    "IsCleanUpDuplicateLearningSourcesJobEnabled": false,
				    "EnableMetaDataFromTenantDB": true,
				    "IsUsageOfLearningSourceIdInQueriesEnabled": false,
				    "isB2TaskFabricApiPathEnabled": true,
				    "TaskFabricApiPath": "/todob2/api/v1",
				    "isRTLFallbackToEnglishEnabled": true,
				    "IsDeltaSyncEnabledForSharePointIngestion": true,
				    "IsQueryChangeForBookMarkCountEnabled": true,
				    "IsAssignmentLocalizationEnabled": true,
				    "EnabledLMSFeatures": [
				      {
				        "SourceType": 9,
				        "IsCatalogEnabled": true,
				        "IsLRSEnabled": true,
				        "IsCatalogPermissionsEnabled": true
				      },
				      {
				        "SourceType": 10,
				        "IsCatalogEnabled": true,
				        "IsLRSEnabled": true
				      },
				      {
				        "SourceType": 11,
				        "IsCatalogEnabled": true,
				        "IsLRSEnabled": true
				      },
				      {
				        "SourceType": 21,
				        "IsCatalogEnabled": false,
				        "IsLRSEnabled": false
				      }
				    ],
				    "IsRecommendationDetailsV2Enabled": true,
				    "IsPopulateDefaultTenantFeaturedSetData": false,
				    "isAddToCalendarEnabled": true,
				    "FeaturedSetDefaultLearningObjectIds": [
				      "b2a0007e-9437-40e7-9f1d-3ae66b9b0987",
				      "c257cff7-84e8-4d2e-a2ad-55a7405e157c",
				      "36723ea6-8ef7-427e-8961-4119692035f4",
				      "d06d88e6-28f4-43a4-932c-de86218dbef4",
				      "ec2508e7-feda-434b-b930-1799332b8bd1"
				    ],
				    "IsLRSDeletePartitionEnabled": false,
				    "IsLRSOldRecordCleanupSchedulerEnabled": false,
				    "StartCleanupProviderIdScheduler": false,
				    "StartCourseCleanupProviderIdScheduler": false,
				    "IsLRSCourseRecordCleanupSchedulerEnabled": false,
				    "CleanupBatchSizes": {
				      "batchProcessSize": "20",
				      "itemsToBeFetched": "20",
				      "itemsToBeReturned": "300"
				    },
				    "IsLRSNewRecordCleanupSchedulerEnabled": true,
				    "isCourseCompletionEnabled": false,
				    "isSystemInitiatedSurveyEnabled": true,
				    "isAssignmentV2Enabled": true,
				    "isFeaturedContentCacheEnabled": true,
				    "EnableSharePoint": true,
				    "CachingGetLearningObjectBySourceTypeEnabled": true,
				    "IsTenantGeoCacheEnabled": true,
				    "SchemaRolloutPercentage": 100,
				    "IsAssignmentAPIEnabledForTenant": false,
				    "IsTier13PsEnabled": false,
				    "IsSkillsoftEnabled": false,
				    "IsTenantLicenseCheckEnabled": true,
				    "isBackfillingEnabled": true,
				    "isDisableSourcesOnLosingLicenseEnabled": true,
				    "premiumLicenseSkus": [
				      "VIVA_LEARNING",
				      "VIVA_LEARNING_FACULTY",
				      "VIVA",
				      "VIVA_FACULTY",
				      "VIVA_GLINT",
				      "VIVA_GLINT_FACULTY"
				    ],
				    "seededLicenseSkus": [
				      "SPE_E3",
				      "SPE_E3_RPA1",
				      "M365_F1",
				      "SPE_F1",
				      "STANDARDPACK",
				      "STANDARDPACKWITHEXCHANGEARCHIVE_ADDON",
				      "STANDARDWOFFPACK",
				      "ENTERPRISEPACK",
				      "ENTERPRISEPACKWITHOUTPROPLUS",
				      "DESKLESSWOFFPACK",
				      "DESKLESSPACK",
				      "DESKLESSPACK_ADDON",
				      "DESKLESSPACK_YAMMER",
				      "SPB_TEST1",
				      "SPE_E3_TEST",
				      "STANDARDPACK_TEST",
				      "ENTERPRISEPACK_TEST",
				      "ENTERPRISEPACKWITHOUTPROPLUS_TEST",
				      "DESKLESSPACK_YAMMER_TEST",
				      "SPE_E5",
				      "DEVELOPERPACK_E5",
				      "SPE_E5_CALLINGMINUTES",
				      "SPE_E5_NOPSTNCONF",
				      "ENTERPRISEPREMIUM",
				      "ENTERPRISEPREMIUM_ESC",
				      "ENTERPRISEPREMIUM_CALLINGMINUTES",
				      "ENTERPRISEPREMIUM_NOPSTNCONF",
				      "ENTERPRISEPREMIUM_NOPBIPBX",
				      "SPE_E5_NOPSTNCONF_TEST",
				      "ENTERPRISEPREMIUM_BACKFILLTEST",
				      "ENTERPRISEPREMIUM_NOPSTNCONF_TEST",
				      "O365_BUSINESS_ESSENTIALS",
				      "SMB_BUSINESS_ESSENTIALS",
				      "SPB",
				      "O365_BUSINESS_PREMIUM",
				      "SMB_BUSINESS_PREMIUM",
				      "M365EDU_A3_FACULTY_RPA1",
				      "M365EDU_A3_FACULTY",
				      "M365EDU_A5_FACULTY",
				      "M365EDU_A5_NOPSTNCONF_FACULTY",
				      "STANDARDWOFFPACK_FACULTY",
				      "STANDARDWOFFPACK_FACULTY_DEVICE",
				      "STANDARDWOFFPACK_IW_FACULTY",
				      "ENTERPRISEPACKPLUS_FACULTY",
				      "ENTERPRISEPREMIUM_FACULTY",
				      "ENTERPRISEPREMIUM_NOPSTNCONF_FACULTY",
				      "STANDARDPACK_FACULTY",
				      "ENTERPRISEPACK_FACULTY",
				      "STANDARDWOFFPACK_HOMESCHOOL_FAC",
				      "M365EDU_A3_FACULTY_TEST",
				      "M365EDU_A5_FACULTY_TEST",
				      "ENTERPRISEPACKPLUS_FACULTY_TEST",
				      "ENTERPRISEPREMIUM_FACULTY_CALLINGMINUTES",
				      "M365EDU_A5_FACULTY_CALLINGMINUTES"
				    ],
				    "isUserAssignedPlansEnabled": true,
				    "isTenantAssignedPlansEnabled": true,
				    "IsPopulateTenantMetadataEnabled": false,
				    "IsEmeaDCEnabled": true,
				    "IsServiceRegionalizationEnabled": true,
				    "IsApacDCEnabled": true,
				    "RegionalLASEndpoints": {
				      "NAM": "https://noam.learningapp.microsoft.com/",
				      "EMEA": "https://emea.learningapp.microsoft.com/",
				      "APAC": "https://sea.learningapp.microsoft.com/"
				    },
				    "GeoDCSettings": [
				      {
				        "GeoName": "NAM",
				        "DCSettings": [
				          {
				            "DCName": "WUS2",
				            "IsEnabled": true
				          },
				          {
				            "DCName": "EUS",
				            "IsEnabled": false
				          }
				        ]
				      },
				      {
				        "GeoName": "EMEA",
				        "DCSettings": [
				          {
				            "DCName": "NEU",
				            "IsEnabled": false
				          },
				          {
				            "DCName": "WEU",
				            "IsEnabled": true
				          }
				        ]
				      },
				      {
				        "GeoName": "APAC",
				        "DCSettings": [
				          {
				            "DCName": "SEA",
				            "IsEnabled": true
				          },
				          {
				            "DCName": "INC",
				            "IsEnabled": false
				          }
				        ]
				      }
				    ],
				    "isLicenseCheckEnabled": true,
				    "IsLMSEnabledTenant": false,
				    "isFeatureContentEnabled": true,
				    "isServiceLevel": true,
				    "isScormPlayerEnabled": true,
				    "isSharepointPermissionsSettingEnabled": true,
				    "isBookmarksEnabled": true,
				    "isViewsTrendEnabled": true,
				    "isSettingsEnabled": true,
				    "isHeadlessMode": true,
				    "isMyLearningCachingEnabled": true,
				    "isTeamsPaddingRemoved": true,
				    "isAssignmentEnabled": true,
				    "isRandomizeLOsDisabled": false,
				    "isThumbnailImageServiceWorkerEnabled": true,
				    "isNewExperienceEnabled": true
				  },
				  "MicrosoftTeamsClientAndroid": {
				    "cerberusContnuosAAAndroid": true,
				    "enableFluentIllustration": true,
				    "low_memory_fix_enabled": true,
				    "enable_spannable_string_comp_fix": true,
				    "enable_optimised_chat_list_refresh": true,
				    "enableIntentTrackVersionedAPI": true,
				    "smb": {
				      "useIntentV3API": true
				    },
				    "platform": {
				      "blockedApps": [
				        "6b9cc557-e24a-4744-a370-407e717f2195",
				        "16332d3e-5eef-4d71-80e6-4d5a86b7b822",
				        "8f79287d-5850-42f1-9af2-48ddf6ef89a8",
				        "7b0641d9-8e1f-4415-99da-c80f8c175c69",
				        "089d82a1-632c-4bb2-b307-23b8166b0113",
				        "2ccabd94-c7ca-4c99-94bb-356d98398409",
				        "acbf66b6-22ab-4e51-98d4-00bb91897116",
				        "829fa155-8058-4b1e-b43a-86efb74da5d4",
				        "4c4ec2e8-4a2c-4bce-8d8f-00fc664a4e5b",
				        "a99cb12c-d46a-4f7a-87c5-06b2da1cb746",
				        "6615e379-7eb9-4e65-afee-2c8a9322aa4b",
				        "c1de80e3-f0e4-4962-bcae-fa23e70366a5",
				        "b756a1a0-1b2f-42ff-90b5-b2a98281fc83",
				        "7a0c1d53-f647-4d76-ab2c-fbc0d73c8bb0",
				        "84c2de91-84e8-4bbf-b15d-9ef33245ad29",
				        "c447be50-d9a3-4c34-b6e4-15ad0ef542bd",
				        "44263ed4-f1ac-4e96-93aa-d24dd50459ea",
				        "b7b8b186-b39d-4028-ac91-84528eebc3e0",
				        "7fabc104-4759-437e-ac5c-9aba7f3a09af",
				        "46fae4d0-faf5-11e9-80f3-53ad33b77bce",
				        "a59fe11a-7ae8-4569-94d1-081c83ab59b6",
				        "effd9d69-e11a-497e-a405-ff79c024e973",
				        "5b876856-c90d-47f8-a6fc-8de780f76cc7",
				        "d7d081d4-d24e-4652-aea6-280db1fd2219",
				        "b8e32e5f-bad2-490b-9470-55d8917cf73a",
				        "9f859fc4-0b17-4bf7-abff-f50a73cbe5ab",
				        "7656ec6e-c63b-4571-8ab8-95d1c451d1e6",
				        "14072831-8a2a-4f76-9294-057bf0b42a68",
				        "a2be9b85-098e-4e62-b51f-756ae2f551a8",
				        "27a3e6d5-98b7-45f7-a04a-7dd7e19edebe",
				        "com.microsoft.teamspace.tab.files.sharepoint",
				        "2399aa4e-bba7-4993-a552-16781e510f76",
				        "eb6dada2-bc16-40fe-b9e9-0d0ab3916704",
				        "cd2d8695-bdc9-4d8e-9620-cc963ed81f41",
				        "83c83baa-0b22-4bc5-9a37-1d8e6ab6fd7b",
				        "3ae27f31-ceea-4d13-a212-cdc9d786eae1",
				        "36ae0e3d-3446-48d0-86cb-b8bde5265cd4",
				        "b712da79-73c8-4d56-8531-1e180c95e9d1",
				        "1a24a3a3-1fda-4f70-abee-40bba8c638e8",
				        "com.microsoft.teamspace.tab.file.staticviewer.excel",
				        "3ed5b337-c2c9-4d5d-b7b4-84ff09a8fc1c",
				        "17e00609-c03b-44e4-b516-fb2d2232e95d",
				        "86ce8ab3-7472-47ef-9cf5-7225ff0c77d5",
				        "9f1a4ae0-6ae2-475d-973d-c89687d03753",
				        "cc649732-0f1c-41be-bb52-fbeaab71c7cf",
				        "e1946271-e466-41f9-adba-c5bbe53e56a4",
				        "474c7f73-c3dd-4b94-96f0-23f7fa771cee",
				        "8bd0dbd9-defe-4a4a-aa75-0c3b5396cad2",
				        "0ec566bc-a37a-46ca-a252-54af50dfa86e",
				        "5fdd80e2-4d58-4c5c-ac85-356c1b2a0bba",
				        "5a0e35f9-d3c8-45b6-9dd9-983ab47f1b83",
				        "90a27c51-5c74-453b-944a-134ba86da790",
				        "7fceea0d-ed46-4394-876a-9b95b55be8e4",
				        "bce03b83-412b-4dfa-ae76-c9171a5f5ed7",
				        "d4460828-ddde-4619-b40b-39412667f7a3",
				        "bd9fb5cb-4d02-4cc6-a7f4-52a8a62d30b7",
				        "442cc7cc-4faa-469c-b8f8-581b2d5bd8aa",
				        "95e54205-5e03-45e7-abef-1e8a41374407",
				        "6eacb5f0-68b0-46f0-9507-9e906c6861fc",
				        "3e036580-07e4-11eb-abda-0962f34e6510",
				        "23a02895-ba8c-40e0-a274-ffa11fc9684f",
				        "2b58c90b-d22b-4b5a-8a1f-6f6e6f3a7e92",
				        "2d96b540-aa26-431b-bc31-222321c762e3",
				        "75d1c59c-8b16-462f-ae74-d98210a39258",
				        "75d3e61c-e5b7-45cc-9b2a-0f8c98a6b91b",
				        "7cd7b1f7-095d-4aaa-9d01-753a015f17b7",
				        "aa3abc6b-b10d-4f6d-b5e0-14af44fab745",
				        "4c0c1f9b-7500-4eac-8d48-3fffe69b3b91",
				        "3564714a-1e68-40c6-ba09-2e9eac549942",
				        "6d1f20e6-538e-4748-896a-1d7d5998d418",
				        "7439ed9e-8ef5-4525-ac80-21d84eb1f90e",
				        "28a06151-a6ba-4817-9ab4-454fb6e59cc6",
				        "f1a2add5-d007-4062-a10a-60f4ea29fdbc",
				        "205214d0-e04b-11e9-9332-5b5c97b60069",
				        "1eb81651-f5d3-4e95-bceb-5ae2ffffd00e",
				        "bf9c1c49-a529-451e-a81d-ac94cfdbec3e",
				        "com.microsoft.teamspace.tab.notes",
				        "b85718a3-6d15-4f59-8fad-b6809c6fc6a9",
				        "ca4b5141-5c46-47bc-a05e-2733d9bd69aa",
				        "5f56e504-48aa-46a0-bd6d-2231355b2830",
				        "00001016-de05-492e-9106-4828fc8a8687",
				        "25b07509-bc6a-4a53-b683-9beb24e55570",
				        "30e8c77f-acd9-453f-958a-82baf329c73d",
				        "com.microsoft.teamspace.tab.powerbi",
				        "com.microsoft.teamspace.tab.file.staticviewer.powerpoint",
				        "57799d60-92cd-40fd-8051-3570a1290828",
				        "65abccad-bf65-497c-8ea2-eec2036b6f13",
				        "a4b9907d-cff2-4771-91d5-30cb794f00c5",
				        "659243fc-ebc2-42fa-aa43-dfcad0f8bcd1",
				        "1d20e5e6-7310-4029-aa63-3efc9e84e926",
				        "2f285d77-896a-4c5f-901e-0902316003b5",
				        "c6462b50-a869-45e1-88b6-734c7087df25",
				        "4608dd75-e769-46f0-8f28-ac18c714cad1",
				        "29d59aa7-28cf-4460-a6be-918f4557e420",
				        "14510476-fa9d-4dad-add9-aa5975a60a8b",
				        "0fdcda7d-5ce6-41a0-b5a3-4fa867815487",
				        "38ff7ef9-c2ff-4a65-9774-a5d338ae708d",
				        "8c9f8e8e-fe2d-4542-84ab-1d30c4a735fc",
				        "7824020d-ce5a-420f-ab91-2dc72f27834a",
				        "3bf2e254-d6c9-4e0c-b269-1c80c1220dc4",
				        "7792759a-43e8-4dc8-9f55-e7b0382c4a67",
				        "1dc264f0-30a4-4585-9ed9-febabfa6fd7e",
				        "73e63b28-e6b1-48fe-9ca5-b6801b5bd4d5",
				        "bcb050bd-ad7e-4e0e-94a7-e38d7fa098c9",
				        "e946766a-060d-4b50-bc90-f8de7b48b184",
				        "effe13ef-00e2-4d55-a207-f2d9d1dd7263",
				        "def85aef-c838-4f6b-b76e-53292aaa43d9",
				        "37664cf9-dd77-4681-b286-430107bea7bf",
				        "32772d29-4df0-4c7d-bade-8f35fe9101a3",
				        "015bf4ec-bc37-4931-9862-ef8686da652b",
				        "1d192ad2-6590-4179-a088-daff383a52b5",
				        "62a00d05-797b-4e83-bf9c-8ea6b3163878",
				        "com.microsoft.teamspace.tab.file.staticviewer.visio",
				        "bae0fc3b-3f87-41d5-a144-02d536f827c3",
				        "51abb001-38d9-4d2a-a877-069e07099ad6",
				        "0924e969-85d8-4acb-8687-faacd6abd228",
				        "6f9f20ca-95d0-4534-8f23-b36ad7e3955a",
				        "com.microsoft.teamspace.tab.file.staticviewer.word",
				        "a671596c-9fb7-40ba-9915-c3420781b0db",
				        "bc4e7b4a-0ae5-49be-a56f-743e16aca230",
				        "8a1da635-7529-4456-b43a-56cbd865c3cf",
				        "39e837f8-e135-4130-94a2-ed89ac575cd1",
				        "88ffccc0-71cf-4451-8783-898b7b944814",
				        "3a54620f-98a1-4804-bcdc-fa7324d8fbd0",
				        "0d820ecd-def2-4297-adad-78056cde7c78",
				        "d7958adf-f419-46fa-941b-1b946497ef84",
				        "1c256a65-83a6-4b5c-9ccf-78f8afb6f1e8",
				        "3e0a4fec-499b-4138-8e7c-71a9d88a62ed"
				      ],
				      "enableOauthForAdaptiveCardsV2": true,
				      "enableSSOForAdaptiveCardsV2": true,
				      "enableAuthenticationBlockUsageForAdaptiveCardsV2": true,
				      "authenticationBlockHonourTimeInMinutesForAdaptiveCardsV2": 360,
				      "clearWebStorage": true,
				      "enableCollabCloudApis": true,
				      "collabCloudEndpointUrl": "https://teams.microsoft.com/api/platform/",
				      "extensibilityMultiResourcesTeamsiteDomainEnabled": true,
				      "extensibilityMultiResourcesMysiteDomainEnabled": true,
				      "enableLOBAppsAcquisitionFix": true,
				      "enableAppInstallationForMessageExtensionAdaptiveCardsV2": true,
				      "enableRefreshForAdaptiveCardsOnClosingTaskModule": true,
				      "enableCardActionInvokeComplianceData": true,
				      "enableAdaptiveCardEmptyChoicesetFix": true,
				      "enableAdaptiveCardDirectorySearch": true,
				      "blacklistedCEAppsInOneOnOneChat": [
				        "81fef3a6-72aa-4648-a763-de824aeafb7d"
				      ],
				      "blacklistedCEAppsInMeetingChat": [
				        "81fef3a6-72aa-4648-a763-de824aeafb7d"
				      ],
				      "blacklistedCEAppsInGroupChat": [],
				      "blacklistedCEAppsInChannel": [],
				      "enableActionExecuteForMessageExtensionAdaptiveCards": true,
				      "enableRefreshForMessageExtensionAdaptiveCards": true,
				      "maxMemberCountForAdaptiveCardsAutomaticRefresh": 60,
				      "shouldConsumePreconsentedState": true,
				      "enableContextMenuForAdaptiveCards": true,
				      "jsonBasedStaticTabEnabled": true,
				      "readSupportedPlatformsFlagForStaticTabsEnabled": true,
				      "readSupportedPlatformsFlagForConfigTabsEnabled": true
				    },
				    "bottomBarLargeFormFactorLeftRailEnabled": true,
				    "enableGuardiansReEntryInviteUpdate": true,
				    "isGuardianHomePageAppEnabled": true,
				    "activityFeedCommunitiesEnabled": true,
				    "enableTflInviteFreeV2ForGroupChat": true,
				    "officeLensWhitelistedTelemetryEvents": [
				      "VideoLaunch",
				      "LaunchLens"
				    ],
				    "enableAudioBluetoothFilterHeadsetOnly": true,
				    "communitiesDeferredDeeplinkEnabled": true,
				    "reportFullyDrawnInMainActivity": false,
				    "isCSAAfdEndpointFromAuthzEnabled": true,
				    "enableMeetingChatBubbles": true,
				    "isParentsContactCardEnabled": true,
				    "isParentsEmailClickEnabled": true,
				    "isParentsPhoneClickEnabled": true,
				    "logsTeamsMemoryData": true,
				    "officeLensMaxVideoDuration": 60000,
				    "enableLazyInitFirebase": "true",
				    "enableChatFps": true,
				    "enableMediaQuickSend": true,
				    "nps": {
				      "isFloodgateEnabled": true
				    },
				    "files": {
				      "isRedirectionToUnionAppEnabled": true,
				      "OfficeAppMetaData": {
				        "WORD": {
				          "storeId": "com.microsoft.office.officehubrow"
				        },
				        "EXCEL": {
				          "storeId": "com.microsoft.office.officehubrow"
				        },
				        "POWERPOINT": {
				          "storeId": "com.microsoft.office.officehubrow"
				        }
				      },
				      "enableVideoCDNSupport": true
				    },
				    "enableSetUserProperties": true,
				    "onePlayerAMSTelemtryEnabled": false,
				    "activityFreFeedEnabled": false,
				    "activityFreFeedV2Enabled": true,
				    "tasksAdaptiveCardEnabled": true,
				    "isParentsAppEnabled": true,
				    "enableInactiveGuardianBanner": true,
				    "isGuardianTeacherChatEnabled": true,
				    "canShowExpandedReactions": true,
				    "enableL1ViewDropShadow": true,
				    "downloadDisabledFileTypes": [
				      "fluid",
				      "one",
				      "onenote",
				      "notes",
				      "notepin",
				      "note",
				      "whiteboard",
				      "loop"
				    ],
				    "nordenModelsSupportedConsole": [
				      "PolyStudioX30",
				      "PolyStudioX50",
				      "PolyStudioX52",
				      "PolyStudioX70",
				      "MeetingBar A20",
				      "MeetingBar A30",
				      "MeetingBar A10",
				      "MeetingBoard 65",
				      "MeetingBoard 86",
				      "NF19B1",
				      "NF20C1",
				      "NF21D1",
				      "AM3X00",
				      "UC-ENGINE-A",
				      "VR0019",
				      "VR0020",
				      "VR0030",
				      "expandvision3t",
				      "ExpandVision5T",
				      "PolyG7500",
				      "RXV80",
				      "RXV81",
				      "RXV200",
				      "Panacast1000",
				      "DBR14",
				      "Board Pro 55",
				      "Board Pro 75",
				      "Room Bar",
				      "Room Kit Pro",
				      "Desk Pro"
				    ],
				    "pptBootstrapperUrl": "https://c1-powerpoint-15.cdn.office.net/pods/s/PptScripts/powerpoint.boot.js",
				    "enableSilentRenamingOnFilenameConflict": true,
				    "shareShortcutsEnabled": true,
				    "shouldDownloadToPublicDirectory": true,
				    "msgAnimations": {
				      "isMsgAnimationsEnabled": true,
				      "msgAnimationsList": [
				        "BALLOON_CELEBRATION",
				        "RISING_HEARTS",
				        "CONFETTI",
				        "FIREWORKS"
				      ]
				    },
				    "groupTemplates": {
				      "enabled": [
				        "holidayPlanning",
				        "family",
				        "friends",
				        "company",
				        "projectCoord",
				        "getTogether",
				        "localCommunity"
				      ],
				      "showAsSuggestionInChatList": [
				        "holidayPlanning",
				        "company",
				        "family"
				      ],
				      "entryExperiment": 1,
				      "enablePersistentEntryPoint": true,
				      "enableCalendarNudge": false,
				      "enableGroupTemplates": true,
				      "catalogNeutralTemplates": [
				        "holidayPlanning",
				        "family",
				        "friends",
				        "company",
				        "projectCoord",
				        "getTogether",
				        "localCommunity"
				      ],
				      "catalogPersonalTemplates": [
				        "holidayPlanning",
				        "family",
				        "friends",
				        "getTogether",
				        "localCommunity",
				        "company",
				        "projectCoord"
				      ],
				      "catalogBusinessTemplates": [
				        "company",
				        "projectCoord",
				        "getTogether",
				        "holidayPlanning",
				        "friends",
				        "family",
				        "localCommunity"
				      ],
				      "chatListNeutralTemplates": [
				        "holidayPlanning",
				        "company",
				        "family"
				      ],
				      "chatListPersonalTemplates": [
				        "holidayPlanning",
				        "family",
				        "friends"
				      ],
				      "chatListBusinessTemplates": [
				        "company",
				        "projectCoord"
				      ],
				      "useIntentTrackService": true
				    },
				    "uploadChunkSizesInMB": [
				      1,
				      1,
				      3,
				      10,
				      10
				    ],
				    "accountPlaceholderIconsEnabled": true,
				    "meetingTenantGetHelpUrl": {
				      "d638243e-4b96-4b21-bd42-ee430faadbfe": "https://go.microsoft.com/fwlink/?linkid=2149542&clcid=0x409",
				      "73588a2a-d95b-4846-8dc4-5c6bbdfc3a72": "https://go.microsoft.com/fwlink/?linkid=2149542&clcid=0x409"
				    },
				    "recordingBotMri": "28:bdd75849-e0a6-4cce-8fc1-d7c0d4da43e5",
				    "notifyPreCallTempNotificationOnStart": false,
				    "notifyInCallTempNotificationOnCreate": false,
				    "notifyInCallTempNotificationOnStart": false,
				    "forceSyncIfNotificationTruncated": true,
				    "enableAliasDiscoverabilitySettings": true,
				    "consumerGroup": {
				      "syncMissingCgEnabled": true
				    },
				    "disableAutoFolderCreationInUpload": true,
				    "meetingTenantIdToName": {
				      "d638243e-4b96-4b21-bd42-ee430faadbfe": "CES",
				      "73588a2a-d95b-4846-8dc4-5c6bbdfc3a72": "CES",
				      "9ed72ea6-487f-4eb2-a8c6-dc36e8136aeb": "SFF SWITCH 2020",
				      "4c00d031-a9ba-448e-9f5c-df8e4f2ef4ea": "SFF SWITCH 2020"
				    },
				    "shouldPreventParallelBlocklistSync": true,
				    "shouldPreventParallelContactGroupSync": true,
				    "shouldPreventParallelAddressBookSync": true,
				    "shouldBlockUIOnAcceptingChat": true,
				    "DTMFOptionEnabled": false,
				    "IpPhoneModelsConferenceDevice": [
				      "CP960",
				      "TrioC60",
				      "UC-2"
				    ],
				    "targetingFetchTagsOnStart": false,
				    "roomControllerReactURL": "https://teams.microsoft.com/extensibility-apps/roomremote/list?host=teams",
				    "gapDetectionBasedNotificationSync": true,
				    "enableTflOptionalTelemetry": true,
				    "tflShowBoldInviteFriendsEnabled": true,
				    "deviceContactTag": true,
				    "mriPhoneEmailCacheSize": 100,
				    "shouldShowPoorNetworkBannerDueToExceptions": false,
				    "shouldShowPoorConnectionBanner": false,
				    "shouldShowConnectingBanner": false,
				    "bandwidthTimerDelayInSeconds": 30,
				    "getRangeValuesForNwExceptionMonitor": [
				      10,
				      4,
				      1
				    ],
				    "newGroupWelcomeScreenType": 1,
				    "isUntitledGroupCreationEnabled": true,
				    "sharedLinkInDashboardEnabled": true,
				    "enableGroupChatCreateSMSUsers": true,
				    "chatFilesTabUploadEnabled": true,
				    "user": {
				      "overrideUserSettingsNamespace": false
				    },
				    "tasksTabInDashboardEnabled": true,
				    "tasksTabInBottomDrawerEnabled": true,
				    "tasksNavigationFromDashboardEnabled": true,
				    "tasksInChatEnabled": true,
				    "Feedback": {
				      "enableOcvFeedback": true,
				      "enableOcvSns": false,
				      "internalLifeFeedbackUrl": "https://aka.ms/teamslifefeedback",
				      "helpArticlesUrl": "https://aka.ms/TeamsPersonalHelp"
				    },
				    "accountAwareToastEnabled": false,
				    "accountAwareToastStayTimeMs": 2000,
				    "enableDeviceContactsSearch": true,
				    "enableServerPeopleSearch": false,
				    "flwPresenceAuditServiceEnabled": true,
				    "Location": {
				      "enableSharedPlaces": true,
				      "sharedPlacesGroupLimit": 10,
				      "enableGeofenceFromPlaces": true,
				      "geofenceTriggerSyncDelay": 10,
				      "enableNearbyPlaces": true,
				      "enableLiveLocation": true,
				      "enableBeaconUploader": true,
				      "enableBeaconTelemetry": true,
				      "enableVerboseTelemetry": false,
				      "enablePassiveTracking": true,
				      "enableIndefiniteSharing": true,
				      "serviceUrlOverride": "https://teams.live.com/api/location/prod/",
				      "batterySettings": {
				        "pushMuteThreshold": 20,
				        "pushMuteDuration": 1800,
				        "activeTrackingThreshold": 40
				      },
				      "durationOptions": [
				        30,
				        1440
				      ],
				      "activeSessionBannerFrequency": 7200,
				      "staticLocationCustomChiclet": true,
				      "enableActivityFeed": true,
				      "enableApp": false,
				      "enableForFederatedChat": true
				    },
				    "placeSearchV2Enabled": true,
				    "shareLocationAmsUploadEnabled": false,
				    "shareLocationV2Enabled": true,
				    "presence": {
				      "TFLPresenceEnabled": true
				    },
				    "enableABContactsSync": true,
				    "addressBookUploadBatchCount": 200,
				    "enableDeviceContactHash": true,
				    "deviceContactHashCacheSize": 100,
				    "overrideThreadTenantId": true,
				    "peoplePickerSectionHeaders": true,
				    "peoplePickerDeviceContacts": true,
				    "peoplePickerSCDMatch": true,
				    "enableAddContactOnMessageSent": true,
				    "enablePresenceUI": false,
				    "enableBlockContact": true,
				    "enableMiniProfilesSync": true,
				    "enableUpdateAvatar": true,
				    "enableDeleteAvatar": true,
				    "enableEditDisplayName": true,
				    "maxQuarantineCounter": 10,
				    "enableInviteFree": true,
				    "scdPingIntervalInDays": 15,
				    "notification": {
				      "enableTFLContext": "true",
				      "useAlwaysSendPush": "true"
				    },
				    "removeFileFromRecentEnabled": true,
				    "allowAnonymousUserShareLocation": true,
				    "allowAnonymousUserShareImages": true,
				    "shouldShowGroupSuggestedMessages": true,
				    "newChatMessageSuggestionEnabled": true,
				    "newOneToOneChatPersonalizationCardEnabled": true,
				    "middletierProfileS2SEnabled": true,
				    "middletierM365S2SEnabled": true,
				    "middleTierOutlookS2SEnabled": true,
				    "stopLoggingScenarioStart": true,
				    "enableFLWPresence": true,
				    "enableOffShiftNoticeDialog": true,
				    "messageForwardingEnabled": true,
				    "mediaFromNativeKeyboardEnabled": true,
				    "getUserProfilesBatchSize": 200,
				    "threadCacheEnabled": "true",
				    "threadCacheSize": 200,
				    "threadUserCacheEnabled": "true",
				    "threadUserCacheSize": 200,
				    "chatConversationCacheEnabled": "true",
				    "chatConversationCacheSize": 100,
				    "threadPropertyAttributeCacheEnabled": "true",
				    "threadPropertyAttributeCacheSize": 200,
				    "conversationCacheEnabled": "true",
				    "conversationCacheSize": 100,
				    "trendingFeedsEnabled": true,
				    "enableContextMenuForFiles": true,
				    "intelligentFeedsEnabled": true,
				    "enableAdaptiveCards": true,
				    "enableFilePreview": true,
				    "chatFilesTab": true,
				    "consumerRegionGmtsEnv": "prod",
				    "TOU Link": "",
				    "TOU Version": 0
				  },
				  "MicrosoftTeamsEcsPrototype": {
				    "enableRecoverThreadV2": true,
				    "enableProfilePictureCropAndResize": true,
				    "enableGraphGroupSmtpAddress": true,
				    "enableUseAadProfilePicturesForExternalUsers": true,
				    "enableBulkAddMembershipV2": true,
				    "enableBulkDeleteMembership": true,
				    "enableETag": true,
				    "enableTeamSiteStatusRetry": true,
				    "enableOnDemandTranslationEndpoint": true,
				    "enableTenantAdminCheckInResourcesSettings": true,
				    "enableFreemium": true,
				    "enableFreemiumBootstrapTeamCreation": true,
				    "enableGetDeepLinkWithTenantIdOnly": true,
				    "enableAcctClaimInToken": true,
				    "enableSubstrateApiForSuggestedGroups": true,
				    "enableWopiActionEdit": true,
				    "enableAppImageClaim": true,
				    "enableUnclaimedAppImageSubstitution": true,
				    "enableSyncTeamsRosterBulkAddMembersV2": true,
				    "enableTeamArchiving": true,
				    "enableImageClaimsTobeNonCritical": true,
				    "enableHidingGroupsInOutlook": true,
				    "enableTenantOwnedApps": true,
				    "enableTenantSettingsControlForLobApps": true,
				    "enableTenantWideTeams": false,
				    "enableCloneTeam": false,
				    "testsettings": true,
				    "enableDeeplinkEscapeDataEncoding": true,
				    "enableOnlineMeetingConfLink": true,
				    "enableUserCacheInRosterSync": true,
				    "enableFreemiumConsumerIdTag": true,
				    "enableSetUserEmailDuringTenantBootstrap": true,
				    "enableGetBatchWithEtagFromSettingsStore": true,
				    "enableOneNoteForwardSyncPendingProvision": true,
				    "enableNiji": true,
				    "enablePolicySettingsCleanUp": true,
				    "useRpoAndRboForGroupCreation": true,
				    "enableChatAppImageClaim": true
				  },
				  "MicrosoftTeamsRetailClients": {
				    "isAATestEnabled": true,
				    "WalkieTalkie": {
				      "PrefetchTokenOnLoad": true,
				      "MaxOutgoingCallDuration": 115000,
				      "SuggestedChannelsRefreshInterval": 3600000,
				      "EnablePrivateChannels": true,
				      "FF": {
				        "BLE_MAX_RETRIES": 5,
				        "NON_STICKY_FS_ENABLED": false,
				        "UseNewBTStack": true,
				        "SCOAutoDisconnectEnabled": true,
				        "SCOAutoDisconnectMillis": 120000,
				        "DisplayBTDotIndicator": false,
				        "IsBleErrorSoundEnabled": false
				      },
				      "EnableNormalization": true,
				      "NormalizationThreshold": -60,
				      "HeadsetNormalizationThreshold": -60,
				      "EnableLastConnectedChannels": true,
				      "EnableGenericAndroidPttIntent": false,
				      "loggingWTExpIdsEnabled": true,
				      "LazyInitializationEnabled": true,
				      "EnableNetworkQualityTest": true,
				      "ShowPoorNetworkBanner": false,
				      "EnableChannelPickerTooltip": true,
				      "EnablePressAndHoldTooltip": true
				    }
				  },
				  "MicrosoftTeamsRetailIOSClients": {
				    "walkieTalkie": {
				      "useWebSocketStateMachineBehavior": false,
				      "normalizationThreshold": -60,
				      "enableAudioNormalization": true,
				      "bleScanStopDelay": 4000,
				      "bleScanStartDelay": 2000,
				      "bleMaxReconnectionRetries": 5,
				      "bleEnabled": true,
				      "bleReconnectEnabled": true,
				      "bleUseCategoryChangeForDisconnect": false,
				      "lowMediaVolumePercentageThreshold": 0.3,
				      "enableNotificationForIncomingCall": true,
				      "enableTraceTelemetry": true,
				      "enablePreConnectWS": true,
				      "enableSuggestedChannels": true,
				      "enablePrivateChannels": true,
				      "logJitterArray": true,
				      "enableWSAutoReconnect": true,
				      "enableWirelessAccessorySupport": true,
				      "enableTrueTime": true,
				      "suggestedChannelsRefreshInterval": 100,
				      "transmitterMaxInactivityTime": 2000,
				      "receiverMaxInactivityTime": 3000,
				      "maxOutgoingCallDuration": 120000,
				      "callMonitorTaskNotifyIntervalDuration": 100,
				      "shortCallDuration": 1000,
				      "shortCallsWindowDuration": 2000,
				      "outgoingCallTransmissionFailureDurationThresholdInSec": 100,
				      "audioPercentageMaxVolume": 0.96,
				      "NTPHost": "www.google.com",
				      "trueTimeInitBackoffWindowDuration": 100,
				      "showPoorNetworkBanner": true,
				      "poorNetworkJitterThreshold": 100,
				      "poorNetworkMaxVarianceThreshold": 100,
				      "enableBGExecution": true,
				      "enableWarningLowVolume": true,
				      "enableQuietHoursSupport": true,
				      "userbiTeamsAriaEnabled": true
				    }
				  },
				  "MicrosoftTeamVivaPulse": {
				    "vivaPulseAccess": false,
				    "vivaPulseHeader": false
				  },
				  "NancyTest": {},
				  "Notifications": {
				    "PNMRegistrarRest": {
				      "ProdEnvURL": "https://teams.microsoft.com/registrar/prod/V3/registrations",
				      "CbcOn": 1,
				      "PushNotificationRegistrarImpl": "REST",
				      "TestEnvURL": "https://edge.skype.net:443/registrar/testenv/V2/registrations",
				      "RetryPolicy": {
				        "Start": 6,
				        "Base": 3,
				        "MaxExponent": 5
				      },
				      "HttpStackConfig": {
				        "connectionTimeout": 30,
				        "requestTimeout": 60
				      },
				      "CrawlRetry": 120,
				      "AuthRetryListSeconds": [
				        1,
				        3,
				        5,
				        60,
				        300
				      ]
				    }
				  },
				  "ODSP_MEE_Mobile": {
				    "gcch": "false",
				    "isEUDBLoggingEnabled": true,
				    "isVCMCookieInvalidateEnabledOn401": true,
				    "isOnloadProgressUpdate": true,
				    "isForceLocaleQSPEnabledForSP": true,
				    "isCookieAttachedToApiBugFixEnabled": true,
				    "is400BadRequestFixEnabled": true,
				    "isBootToTabEventEnabled": true,
				    "isDashcardCacheExpiryExpEnabled": true,
				    "isL2BackButtonListenerEnabled": true,
				    "isL1CardsDisappearingEnabled": true,
				    "isLocationActionEnabled": true,
				    "isQVModalOverModalEnabled": true,
				    "isTeamsLinkOpenInAppFromQVEnabled": true,
				    "isForceLocaleQspEnabled": true,
				    "isUrlDecodingEnabledInLinkManager": true,
				    "isL1CardsBatchUpdateEnabled": true,
				    "L1CardsUpdateDelay": 20,
				    "isAuthEnabledForBackgroundImage": true,
				    "isBackgroundEnabledForIOSSpinner": true,
				    "isQVGetSizeFixEnabled": true,
				    "isSVGAndFluentSupportEnabledForQV": true,
				    "isConfirmationDialogEnabled": true,
				    "isSPFxCookieEnabledForIsolatedBridge": true,
				    "isSPFxIsolatedCookieFetchForAndroidEnabled": true,
				    "isThirdPartyCookiesEnabledForBridge": true,
				    "isLinkManagerShouldComponentUpdateFixEnabled": true,
				    "isDashboardLoadRetryonBridgeRedirect": true,
				    "showVivaIcon": true,
				    "isSelectMediaActionEnabled": true,
				    "isCookieManagerEnabled": true,
				    "isL2SpinnerPositionFixEnabled": true,
				    "isPageContextFetchingEnabled": true,
				    "showSettingsPageIcon": true,
				    "shouldReloadBridgeOnPullRefresh": true,
				    "isDeepLinkEnabled": false,
				    "isL2ErrorDescriptionEnabled": false,
				    "showBookmarkIcon": true,
				    "isResourcesTabEnabled": true,
				    "isYammerL2WebViewEnabled": true,
				    "isDashDevSettingsEnabled": false,
				    "isDevKitchenEnabled": false,
				    "isConfigApiEnabled": true,
				    "isDarkThemeEnabled": true,
				    "isQuickLookEnabled": true,
				    "isDashErrorHandlingEnabled": true,
				    "isSPSocialBarEnabled": true,
				    "onlyNewSchemaLog": false,
				    "isSPFx1PTokenFetchEnabled": true,
				    "triggerSPFxTokenFetchOnAppInit": false,
				    "isPerfMetricEnabledInDevSettings": false,
				    "isFileOpenInModalCheckEnabled": false,
				    "isDashErrorScreenDebugMsgEnabled": false,
				    "isDashboardLKGStateEnabled": false,
				    "isNewsLinkNewExpEnabled": true,
				    "ExternalModal": true,
				    "isFileCheckEnabled": true,
				    "isInterceptViaLinkManagerEnabled": true,
				    "isModernClassicCheckEnabled": true,
				    "isOpenDocumentInterceptionEnabled": true,
				    "isRedeemSharingHeaderEnabled": true,
				    "isSPALinkInterceptionEnabled": true,
				    "isSPFxImageUserAgentEnabled": true,
				    "isSkipFoldersFromInterception": true,
				    "isSPCookieBGFetchEnabled": true,
				    "isBridgeURLBGFetchEnabled": true,
				    "isVerboseLoggingForDebuggingEnabled": false,
				    "isDashboardDiagnosticDataEnabled": false,
				    "isSPBackHandlingEnabled": true,
				    "loadingProgress": 0.65,
				    "isFREEnabled": true,
				    "useCookieForAsJsonAPI": true,
				    "isDarkModeEnabledForExternalModal": true,
				    "isTabletErrorHandlingEnabled": true,
				    "isSPFxTokenFetchForAppPrincipalsEnabled": true,
				    "isSelectMediaActionV2Enabled": false,
				    "isSPFxTokenFetchwithAPIFormatDisabled": true,
				    "isStreamNewExpEnabled": true,
				    "isVideoNewsExperienceEnabled": true,
				    "isSPFxTokenFetchWithAuthClaimAPI": false,
				    "isSPPeopleCardEnabled": true
				  },
				  "OpConfig": {
				    "FELayer": {
				      "CT2": false
				    }
				  },
				  "OrchestrationTest": {
				    "Testx": true,
				    "FeatureX": true,
				    "Enabled": true,
				    "EnableFeatureX": true
				  },
				  "OsamaTest": {
				    "Config": {
				      "BlackListConfig": {
				        "TenantIds": [
				          "tenant2"
				        ]
				      }
				    }
				  },
				  "PeopleImport": {
				    "endpoint": "https://peopleimport.skype.com/v1.0",
				    "serviceSettings": {
				      "experiment": "default",
				      "enabled": "true"
				    }
				  },
				  "PeopleRecommendation": {
				    "serviceSettings": {
				      "experiment": "hide-annotations-3",
				      "minMutualFriendsToHideAnnotations": 3,
				      "recommend": "true",
				      "showRecommendationsFromGraph": "false",
				      "showRecommendationsFromScd": "true",
				      "showRecommendationsFromScdGraph": "false"
				    },
				    "endpoint": "https://peoplerecommendations.skype.com/v1.1/recommend",
				    "cacheTimeoutInHours": 240
				  },
				  "PeopleSearch": {
				    "serviceSettings": {
				      "experiment": "MinimumFriendsForAnnotationsEnabled",
				      "minimumFriendsForAnnotationsEnabled": "true",
				      "minimumFriendsForAnnotations": 2,
				      "demotionScoreEnabled": "true",
				      "geoProximity": "disabled"
				    },
				    "v2Endpoint": "https://skypegraph.skype.com/v2.0/search"
				  },
				  "PortalWebClient": {
				    "TFL": {
				      "GDPRExportPage": {
				        "Enabled": true
				      }
				    },
				    "S4LAssetsVersion": "8.90.0.407",
				    "S4LAssetsVersion-Default-Preview": "8.91.76.304",
				    "IsMurphyProtected": false,
				    "CallEcsPerRequest": true,
				    "isEligible": true,
				    "isGuesthostFacebookSharingEnabled": true,
				    "CSP": "default-src 'self' blob: https://*.skype.com https://*.skypeassets.com; script-src https://*.skype.com https://*.skypeassets.com https://www.bing.com https://*.virtualearth.net 'unsafe-eval' 'report-sample'; style-src 'self' https://*.skype.com https://*.skypeassets.com https://www.bing.com 'unsafe-inline'; worker-src 'self' blob:; frame-ancestors 'self' https://*.skype.com https://login.microsoftonline.com; connect-src 'self' blob: data: https://*.skype.com https://*.skypeassets.com https://*.bing.com https://*.live.com https://*.aria.microsoft.com https://*.trouter.io wss://*.skype.com wss://*.skype.com:443 https://*.bingapis.com wss://wsapi.skype.net wss://wsapi-dev.skype.net wss://wsapi-qa.skype.net https://*.virtualearth.net https://api.foursquare.com https://skypesmssfe.trafficmanager.net https://search.knowledge.store https://outlook.office.com https://dynmsg.modpim.com https://teams.microsoft.com https://*.teams.microsoft.com https://login.microsoftonline.com https://login.windows.net https://substrate.office.com/ https://rink.hockeyapp.net/ https://*.translatorv2.skype.net https://graph.microsoft.com http://www.msftconnecttest.com/ https://api.cortana.ai/ https://gateway.zscaler.net https://gateway.zscalerone.net https://gateway.zscalertwo.net https://gateway.zscalerthree.net https://gateway.zscloud.net https://login.zscalerone.net https://api.giphy.com https://api.tenor.com https://www.googleapis.com https://*.msedge.net https://outlook.office365.com https://*.measure.office.com; img-src data: blob: https://*.skype.com https://*.skypeassets.com https://*.skypeassets.net https://*.storage.msn.com https://*.storage.live.com https://skypeapps.azureedge.net https://bot-framework.azureedge.net https://botavatar.azureedge.net https://mscorpmedia.azureedge.net https://az705183.vo.msecnd.net https://botresources.blob.core.windows.net https://*.bing.com https://*.bingapis.com https://*.virtualearth.net https://igx.4sqi.net https://fastly.4sqi.net https://outlook.office.com https://login.microsoftonline.com https://login.windows.net https://*.1drv.com https://spoprod-a.akamaihd.net https://*.measure.office.com https://*.msedge.net https://outlook.office365.com https://*.measure.office.com https://substrate.office.com https://outlook.live.com; media-src skypevideo: blob: https://*; font-src data: https://*.skype.com https://*.skype.net https://*.skypeassets.com; form-action 'self' data: https://login.skype.com https://login.live.com; child-src https://*.skype.com https://*.skype.net https://login.skype.com https://login.live.com https://*.bing.com https://login.microsoftonline.com/ https://skypeapps.azureedge.net/; report-uri https://edge.skype.com/r/c; block-all-mixed-content",
				    "PrefetchLinksJoin": "[{\"Url\":\"https://join.secure.skypeassets.com\",\"Rel\":\"preconnect\",\"IsCors\":false},{\"Url\":\"https://a.lw.skype.com\",\"Rel\":\"preconnect\",\"IsCors\":false},{\"Url\":\"https://login.live.com\",\"Rel\":\"preconnect\",\"IsCors\":false},{\"Url\":\"https://api.join.skype.com\",\"Rel\":\"preconnect\",\"IsCors\":true},{\"Url\":\"https://web.skype.com\",\"Rel\":\"preconnect\",\"IsCors\":false},{\"Url\":\"https://secure.skypeassets.com\",\"Rel\":\"preconnect\",\"IsCors\":false},{\"Url\":\"https://secure.skypeassets.com\",\"Rel\":\"preconnect\",\"IsCors\":true},{\"Url\":\"https://browser.pipe.aria.microsoft.com\",\"Rel\":\"preconnect\",\"IsCors\":true},{\"Url\":\"https://browser.pipe.aria.microsoft.com\",\"Rel\":\"preconnect\",\"IsCors\":false},{\"Url\":\"https://secure.skypeassets.com/wcss/__ASSETSVERSION__/js/vendor2.js\",\"Rel\":\"prefetch\",\"IsCors\":true},{\"Url\":\"https://secure.skypeassets.com/wcss/__ASSETSVERSION__/js/calling.js\",\"Rel\":\"prefetch\",\"IsCors\":true},{\"Url\":\"https://secure.skypeassets.com/wcss/__ASSETSVERSION__/js/core.js\",\"Rel\":\"prefetch\",\"IsCors\":true},{\"Url\":\"https://secure.skypeassets.com/wcss/__ASSETSVERSION__/js/messaging.js\",\"Rel\":\"prefetch\",\"IsCors\":true},{\"Url\":\"https://secure.skypeassets.com/wcss/__ASSETSVERSION__/js/vendor.js\",\"Rel\":\"prefetch\",\"IsCors\":true},{\"Url\":\"https://secure.skypeassets.com/wcss/__ASSETSVERSION__/js/app.js\",\"Rel\":\"prefetch\",\"IsCors\":true}]"
				  },
				  "PstnDynamicRouting": {
				    "DynamicRouting": {
				      "Version": "V3"
				    }
				  },
				  "PstnHub": {
				    "EmergencyHardening": {
				      "Enabled": true
				    },
				    "SipReplacesHeader": {
				      "Disabled": false
				    },
				    "BVCaptchaIvrBot": {
				      "Enabled": "false",
				      "Enforced": "false"
				    },
				    "WholesaleTrunkConfigOverridesOutbound": {
				      "ExcludedCodecs": "SILK_16, G722_2, G722, SIREN, G729, CN_16, RED_8,CN_8",
				      "PreferredCodecOrder": "SILK_8, PCMU, PCMA",
				      "ExtensionParameters": {
				        "EnableMediaStackTracing": "true",
				        "DisableSessionTimer": "true",
				        "Enable181ProvAnswer": "true",
				        "EnableHistoryInfoTransparency": "true",
				        "EnableCauseInRuri": "true"
				      }
				    },
				    "IsOutboundConsumerAnonymousCli": {
				      "Enabled": true
				    },
				    "DRCaptchaIvrBot": {
				      "Enabled": "false",
				      "Enforced": "false"
				    },
				    "ConsumerCaptchaIvrBot": {
				      "Enabled": "true",
				      "Enforced": "false"
				    },
				    "MfaTrunkConfigOverridesOutbound": {
				      "ExcludedCodecs": "SILK_16, G722_2, G722, SIREN, SILK_8, G729, CN_16, RED_8,CN_8",
				      "PreferredCodecOrder": "PCMU, PCMA",
				      "ExtensionParameters": {
				        "EnableMediaStackTracing": "true",
				        "DisableSessionTimer": "true",
				        "Enable181ProvAnswer": "true",
				        "EnableHistoryInfoTransparency": "true",
				        "EnableCauseInRuri": "true"
				      }
				    },
				    "AcsEntitlement": {
				      "Enabled": true,
				      "SipInterfaceEnabled": true,
				      "FreeCall": false
				    },
				    "AcsTrunkConfigOverridesInbound": {
				      "ExtensionParameters": {
				        "EnableMediaStackTracing": "true",
				        "Enable181ProvAnswer": "true",
				        "EnableHistoryInfoTransparency": "true"
				      }
				    },
				    "AcsTrunkConfigOverridesOutbound": {
				      "ExtensionParameters": {
				        "EnableMediaStackTracing": "true",
				        "Enable181ProvAnswer": "true",
				        "EnableHistoryInfoTransparency": "true",
				        "EnableCauseInRuri": "true"
				      }
				    },
				    "Redis": {
				      "PstnHub": {
				        "Enabled": true,
				        "CircuitBreakerEnabled": true,
				        "CircuitBreakerClosedStateFailureThresholdPercentage": 70,
				        "CircuitBreakerClosedStateAggregationIntervalSeconds": 120,
				        "CircuitBreakerOpenStateIntervalSeconds": 60,
				        "CircuitBreakerHalfOpenStateSuccessThresholdPercentage": 50,
				        "CircuitBreakerHalfOpenStateAggregationIntervalSeconds": 120,
				        "CircuitBreakerHalfOpenStateSamplignRateIntervalSeconds": 2,
				        "CircuitBreakerOpenStateDoomedThreshold": 10
				      }
				    },
				    "ConsumerTrunkConfigOverridesOutbound": {
				      "ExcludedCodecs": "SILK_16, G722_2, G722, SIREN, SILK_8, G729, CN_16, RED_8,CN_8",
				      "ExtensionParameters": {
				        "EnableMediaStackTracing": "true",
				        "DisableSessionTimer": "true",
				        "Enable181ProvAnswer": "true",
				        "EnableHistoryInfoTransparency": "true",
				        "EnableCauseInRuri": "true"
				      }
				    },
				    "ConsumerTrunkConfigOverridesInbound": {
				      "ExtensionParameters": {
				        "EnableMediaStackTracing": "true",
				        "DisableSessionTimer": "true",
				        "DisableForkingNotification": "true",
				        "Enable181ProvAnswer": "true",
				        "EnableHistoryInfoTransparency": "true"
				      }
				    },
				    "BVTrunkConfigOverridesInbound": {
				      "ExtensionParameters": {
				        "EnableMediaStackTracing": "true",
				        "EnablePreferSfB": "true",
				        "EnableCallTransferWithLocalRingbackTone": "true",
				        "EnableCallTransferWithLocalRingbackToneInUcap": "true",
				        "Enable181ProvAnswer": "true",
				        "EnableHistoryInfoTransparency": "true"
				      }
				    },
				    "BVTrunkConfigOverridesOutbound": {
				      "ExtensionParameters": {
				        "EnableMediaStackTracing": "true",
				        "EnableCallTransferWithLocalRingbackTone": "true",
				        "EnableCallTransferWithLocalRingbackToneInUcap": "true",
				        "Enable181ProvAnswer": "true",
				        "EnableHistoryInfoTransparency": "true",
				        "EnableCauseInRuri": "true"
				      }
				    },
				    "TrunkConfigOverridesInbound": {
				      "CallConnectionIndication": "Fake180",
				      "ExtensionParameters": {
				        "EnableMediaStackTracing": "true",
				        "EnableCallTransferWithLocalRingbackTone": "true",
				        "EnableCallTransferWithLocalRingbackToneInUcap": "true",
				        "Enable181ProvAnswer": "true",
				        "EnableHistoryInfoTransparency": "true"
				      }
				    },
				    "TrunkConfigOverridesOutbound": {
				      "ExtensionParameters": {
				        "EnableMediaStackTracing": "true",
				        "EnableCallTransferWithLocalRingbackTone": "true",
				        "EnableCallTransferWithLocalRingbackToneInUcap": "true",
				        "Enable181ProvAnswer": "true",
				        "EnableHistoryInfoTransparency": "true",
				        "EnableCauseInRuri": "true"
				      }
				    },
				    "TrunkHealth": {
				      "BvDemotingEnabled": true,
				      "DrDemotingEnabled": false,
				      "SipProxyFullInterleavingEnabled": false
				    },
				    "NgTrunkHealth": {
				      "BvDemotingEnabled": true,
				      "DrDemotingEnabled": true,
				      "Ttl": 5,
				      "FailedStatusCodes": [],
				      "BvMonitoringEnabled": true,
				      "DrMonitoringEnabled": false,
				      "BvDemotingSelectorEnabled": true,
				      "DrDemotingSelectorEnabled": false,
				      "SnapshotsDownloadEnabled": true,
				      "BvDemotingSelectorShadowModeEnabled": true,
				      "DrDemotingSelectorShadowModeEnabled": true
				    },
				    "ZoneACountryCodes": [
				      "AU",
				      "AT",
				      "BE",
				      "BR",
				      "BG",
				      "CA",
				      "CN",
				      "HR",
				      "CZ",
				      "DK",
				      "EE",
				      "FI",
				      "FR",
				      "DE",
				      "GR",
				      "HK",
				      "HU",
				      "IN",
				      "IE",
				      "IT",
				      "JP",
				      "LU",
				      "MY",
				      "MX",
				      "NL",
				      "NZ",
				      "NO",
				      "PL",
				      "PT",
				      "PR",
				      "RO",
				      "RU",
				      "SG",
				      "SK",
				      "SL",
				      "ZA",
				      "KR",
				      "ES",
				      "SE",
				      "CH",
				      "TW",
				      "TH",
				      "GB",
				      "US"
				    ],
				    "CountryToRegion": {
				      "AD": [
				        "euwe",
				        "euno"
				      ],
				      "AE": [
				        "euwe",
				        "euno"
				      ],
				      "AF": [
				        "euwe",
				        "euno"
				      ],
				      "AG": [
				        "usea2",
				        "uswe"
				      ],
				      "AI": [
				        "usea2",
				        "uswe"
				      ],
				      "AL": [
				        "euwe",
				        "euno"
				      ],
				      "AM": [
				        "euwe",
				        "euno"
				      ],
				      "AN": [
				        "usea2",
				        "uswe"
				      ],
				      "AO": [
				        "euwe",
				        "euno"
				      ],
				      "AQ": [
				        "usea2",
				        "uswe"
				      ],
				      "AR": [
				        "brso"
				      ],
				      "AS": [
				        "usea2",
				        "uswe"
				      ],
				      "AT": [
				        "euwe",
				        "euno"
				      ],
				      "AU": [
				        "ause",
				        "auea"
				      ],
				      "AW": [
				        "usea2",
				        "uswe"
				      ],
				      "AZ": [
				        "euwe",
				        "euno"
				      ],
				      "BA": [
				        "euwe",
				        "euno"
				      ],
				      "BB": [
				        "usea2",
				        "uswe"
				      ],
				      "BD": [
				        "asse"
				      ],
				      "BE": [
				        "euwe",
				        "euno",
				        "frce"
				      ],
				      "BF": [
				        "zano"
				      ],
				      "BG": [
				        "euwe",
				        "euno",
				        "frce"
				      ],
				      "BH": [
				        "euwe",
				        "euno"
				      ],
				      "BI": [
				        "zano"
				      ],
				      "BJ": [
				        "zano"
				      ],
				      "BM": [
				        "usea2",
				        "uswe"
				      ],
				      "BN": [
				        "asse"
				      ],
				      "BO": [
				        "usea2",
				        "uswe"
				      ],
				      "BR": [
				        "brso"
				      ],
				      "BS": [
				        "usea2",
				        "uswe"
				      ],
				      "BT": [
				        "asse"
				      ],
				      "BV": [
				        "usea2",
				        "uswe"
				      ],
				      "BW": [
				        "zano"
				      ],
				      "BY": [
				        "euwe",
				        "euno"
				      ],
				      "BZ": [
				        "usea2",
				        "uswe"
				      ],
				      "CA": [
				        "usea2",
				        "uswe"
				      ],
				      "CC": [
				        "asse"
				      ],
				      "CD": [
				        "zano"
				      ],
				      "CF": [
				        "zano"
				      ],
				      "CG": [
				        "euwe",
				        "euno"
				      ],
				      "CH": [
				        "euwe",
				        "euno"
				      ],
				      "CI": [
				        "euwe",
				        "euno"
				      ],
				      "CK": [
				        "asse"
				      ],
				      "CL": [
				        "usea2",
				        "uswe"
				      ],
				      "CM": [
				        "euwe",
				        "euno"
				      ],
				      "CN": [
				        "jawe"
				      ],
				      "CO": [
				        "usea2",
				        "uswe"
				      ],
				      "CR": [
				        "usea2",
				        "uswe"
				      ],
				      "CU": [
				        "usea2",
				        "uswe"
				      ],
				      "CV": [
				        "euwe",
				        "euno"
				      ],
				      "CX": [
				        "asse"
				      ],
				      "CY": [
				        "euwe",
				        "euno"
				      ],
				      "CZ": [
				        "euwe",
				        "euno"
				      ],
				      "DE": [
				        "euwe",
				        "euno"
				      ],
				      "DJ": [
				        "euwe",
				        "euno"
				      ],
				      "DK": [
				        "euwe",
				        "euno"
				      ],
				      "DM": [
				        "usea2",
				        "uswe"
				      ],
				      "DO": [
				        "usea2",
				        "uswe"
				      ],
				      "DZ": [
				        "euwe",
				        "euno"
				      ],
				      "EC": [
				        "usea2",
				        "uswe"
				      ],
				      "EE": [
				        "euwe",
				        "euno"
				      ],
				      "EG": [
				        "euwe",
				        "euno"
				      ],
				      "EH": [
				        "euwe",
				        "euno"
				      ],
				      "ER": [
				        "euwe",
				        "euno"
				      ],
				      "ES": [
				        "euwe",
				        "euno"
				      ],
				      "ET": [
				        "euwe",
				        "euno"
				      ],
				      "FI": [
				        "euwe",
				        "euno"
				      ],
				      "FJ": [
				        "asse"
				      ],
				      "FK": [
				        "euwe",
				        "euno"
				      ],
				      "FM": [
				        "jawe"
				      ],
				      "FO": [
				        "euwe",
				        "euno"
				      ],
				      "FR": [
				        "euwe",
				        "euno"
				      ],
				      "GA": [
				        "euwe",
				        "euno"
				      ],
				      "GB": [
				        "euwe",
				        "euno"
				      ],
				      "GD": [
				        "usea2",
				        "uswe"
				      ],
				      "GE": [
				        "euwe",
				        "euno"
				      ],
				      "GF": [
				        "usea2",
				        "uswe"
				      ],
				      "GG": [
				        "euwe",
				        "euno"
				      ],
				      "GH": [
				        "euwe",
				        "euno"
				      ],
				      "GI": [
				        "euwe",
				        "euno"
				      ],
				      "GL": [
				        "euwe",
				        "euno"
				      ],
				      "GM": [
				        "euwe",
				        "euno"
				      ],
				      "GN": [
				        "euwe",
				        "euno"
				      ],
				      "GP": [
				        "usea2",
				        "uswe"
				      ],
				      "GQ": [
				        "euwe",
				        "euno"
				      ],
				      "GR": [
				        "euwe",
				        "euno"
				      ],
				      "GS": [
				        "euwe",
				        "euno"
				      ],
				      "GT": [
				        "usea2",
				        "uswe"
				      ],
				      "GU": [
				        "jawe"
				      ],
				      "GW": [
				        "euwe",
				        "euno"
				      ],
				      "GY": [
				        "usea2",
				        "uswe"
				      ],
				      "HK": [
				        "jawe"
				      ],
				      "HM": [
				        "asse"
				      ],
				      "HN": [
				        "usea2",
				        "uswe"
				      ],
				      "HR": [
				        "euwe",
				        "euno"
				      ],
				      "HT": [
				        "usea2",
				        "uswe"
				      ],
				      "HU": [
				        "euwe",
				        "euno"
				      ],
				      "ID": [
				        "asse"
				      ],
				      "IE": [
				        "euwe",
				        "euno"
				      ],
				      "IL": [
				        "euwe",
				        "euno"
				      ],
				      "IM": [
				        "euwe",
				        "euno"
				      ],
				      "IN": [
				        "asse"
				      ],
				      "IO": [
				        "asse"
				      ],
				      "IQ": [
				        "euwe",
				        "euno"
				      ],
				      "IR": [
				        "euwe",
				        "euno"
				      ],
				      "IS": [
				        "euwe",
				        "euno"
				      ],
				      "IT": [
				        "euwe",
				        "euno"
				      ],
				      "JE": [
				        "euwe",
				        "euno"
				      ],
				      "JM": [
				        "usea2",
				        "uswe"
				      ],
				      "JO": [
				        "euwe",
				        "euno"
				      ],
				      "JP": [
				        "jpea",
				        "jpwe"
				      ],
				      "KE": [
				        "euwe",
				        "euno"
				      ],
				      "KG": [
				        "asse"
				      ],
				      "KH": [
				        "asse"
				      ],
				      "KI": [
				        "asse"
				      ],
				      "KM": [
				        "euwe",
				        "euno"
				      ],
				      "KN": [
				        "usea2",
				        "uswe"
				      ],
				      "KP": [
				        "jawe"
				      ],
				      "KR": [
				        "jawe"
				      ],
				      "KW": [
				        "euwe",
				        "euno"
				      ],
				      "KY": [
				        "usea2",
				        "uswe"
				      ],
				      "KZ": [
				        "euwe",
				        "euno"
				      ],
				      "LA": [
				        "asse"
				      ],
				      "LB": [
				        "euwe",
				        "euno"
				      ],
				      "LC": [
				        "usea2",
				        "uswe"
				      ],
				      "LI": [
				        "euwe",
				        "euno"
				      ],
				      "LK": [
				        "asse"
				      ],
				      "LR": [
				        "euwe",
				        "euno"
				      ],
				      "LS": [
				        "euwe",
				        "euno"
				      ],
				      "LT": [
				        "euwe",
				        "euno"
				      ],
				      "LU": [
				        "euwe",
				        "euno"
				      ],
				      "LV": [
				        "euwe",
				        "euno"
				      ],
				      "LY": [
				        "euwe",
				        "euno"
				      ],
				      "MA": [
				        "euwe",
				        "euno"
				      ],
				      "MC": [
				        "euwe",
				        "euno"
				      ],
				      "MD": [
				        "euwe",
				        "euno"
				      ],
				      "ME": [
				        "euwe",
				        "euno"
				      ],
				      "MG": [
				        "euwe",
				        "euno"
				      ],
				      "MH": [
				        "jaea"
				      ],
				      "MK": [
				        "euwe",
				        "euno"
				      ],
				      "ML": [
				        "euwe",
				        "euno"
				      ],
				      "MM": [
				        "asse"
				      ],
				      "MN": [
				        "jawe"
				      ],
				      "MO": [
				        "jawe"
				      ],
				      "MP": [
				        "jawe"
				      ],
				      "MQ": [
				        "usea2",
				        "uswe"
				      ],
				      "MR": [
				        "euwe",
				        "euno"
				      ],
				      "MS": [
				        "usea2",
				        "uswe"
				      ],
				      "MT": [
				        "euwe",
				        "euno"
				      ],
				      "MU": [
				        "euwe",
				        "euno"
				      ],
				      "MV": [
				        "asse"
				      ],
				      "MW": [
				        "euwe",
				        "euno"
				      ],
				      "MX": [
				        "usea2",
				        "uswe"
				      ],
				      "MY": [
				        "asse"
				      ],
				      "MZ": [
				        "euwe",
				        "euno"
				      ],
				      "NA": [
				        "euwe",
				        "euno"
				      ],
				      "NC": [
				        "asse"
				      ],
				      "NE": [
				        "euwe",
				        "euno"
				      ],
				      "NF": [
				        "asse"
				      ],
				      "NG": [
				        "euwe",
				        "euno"
				      ],
				      "NI": [
				        "usea2",
				        "uswe"
				      ],
				      "NL": [
				        "euwe",
				        "euno"
				      ],
				      "NO": [
				        "euwe",
				        "euno"
				      ],
				      "NP": [
				        "asse"
				      ],
				      "NR": [
				        "jaea"
				      ],
				      "NU": [
				        "asse"
				      ],
				      "NZ": [
				        "ause",
				        "auea"
				      ],
				      "OM": [
				        "euwe",
				        "euno"
				      ],
				      "PA": [
				        "usea2",
				        "uswe"
				      ],
				      "PE": [
				        "usea2",
				        "uswe"
				      ],
				      "PF": [
				        "jawe"
				      ],
				      "PG": [
				        "asse"
				      ],
				      "PH": [
				        "asse"
				      ],
				      "PK": [
				        "asse"
				      ],
				      "PL": [
				        "euwe",
				        "euno"
				      ],
				      "PM": [
				        "usea2",
				        "uswe"
				      ],
				      "PN": [
				        "jawe"
				      ],
				      "PR": [
				        "usea2",
				        "uswe"
				      ],
				      "PS": [
				        "euwe",
				        "euno"
				      ],
				      "PT": [
				        "euwe",
				        "euno"
				      ],
				      "PW": [
				        "asse"
				      ],
				      "PY": [
				        "usea2",
				        "uswe"
				      ],
				      "QA": [
				        "euwe",
				        "euno"
				      ],
				      "RE": [
				        "euwe",
				        "euno"
				      ],
				      "RO": [
				        "euwe",
				        "euno"
				      ],
				      "RS": [
				        "euwe",
				        "euno"
				      ],
				      "RU": [
				        "euwe",
				        "euno"
				      ],
				      "RW": [
				        "euwe",
				        "euno"
				      ],
				      "SA": [
				        "euwe",
				        "euno"
				      ],
				      "SB": [
				        "asse"
				      ],
				      "SC": [
				        "euwe",
				        "euno"
				      ],
				      "SD": [
				        "euwe",
				        "euno"
				      ],
				      "SE": [
				        "euwe",
				        "euno"
				      ],
				      "SG": [
				        "asse"
				      ],
				      "SH": [
				        "euwe",
				        "euno"
				      ],
				      "SI": [
				        "euwe",
				        "euno"
				      ],
				      "SJ": [
				        "euwe",
				        "euno"
				      ],
				      "SK": [
				        "euwe",
				        "euno"
				      ],
				      "SL": [
				        "euwe",
				        "euno"
				      ],
				      "SM": [
				        "euwe",
				        "euno"
				      ],
				      "SN": [
				        "euwe",
				        "euno"
				      ],
				      "SO": [
				        "euwe",
				        "euno"
				      ],
				      "SR": [
				        "usea2",
				        "uswe"
				      ],
				      "ST": [
				        "euwe",
				        "euno"
				      ],
				      "SV": [
				        "usea2",
				        "uswe"
				      ],
				      "SY": [
				        "euwe",
				        "euno"
				      ],
				      "SZ": [
				        "euwe",
				        "euno"
				      ],
				      "TC": [
				        "usea2",
				        "uswe"
				      ],
				      "TD": [
				        "euwe",
				        "euno"
				      ],
				      "TF": [
				        "asse"
				      ],
				      "TG": [
				        "euwe",
				        "euno"
				      ],
				      "TH": [
				        "asse"
				      ],
				      "TJ": [
				        "asse"
				      ],
				      "TK": [
				        "asse"
				      ],
				      "TL": [
				        "asse"
				      ],
				      "TM": [
				        "euwe",
				        "euno"
				      ],
				      "TN": [
				        "euwe",
				        "euno"
				      ],
				      "TO": [
				        "asse"
				      ],
				      "TR": [
				        "euwe",
				        "euno"
				      ],
				      "TT": [
				        "usea2",
				        "uswe"
				      ],
				      "TV": [
				        "asse"
				      ],
				      "TW": [
				        "jawe"
				      ],
				      "TZ": [
				        "euwe",
				        "euno"
				      ],
				      "UA": [
				        "euwe",
				        "euno"
				      ],
				      "UG": [
				        "euwe",
				        "euno"
				      ],
				      "US": [
				        "usea2",
				        "uswe"
				      ],
				      "UY": [
				        "usea2",
				        "uswe"
				      ],
				      "UZ": [
				        "euwe",
				        "euno"
				      ],
				      "VA": [
				        "euwe",
				        "euno"
				      ],
				      "VC": [
				        "usea2",
				        "uswe"
				      ],
				      "VE": [
				        "usea2",
				        "uswe"
				      ],
				      "VG": [
				        "usea2",
				        "uswe"
				      ],
				      "VI": [
				        "usea2",
				        "uswe"
				      ],
				      "VN": [
				        "asse"
				      ],
				      "VU": [
				        "asse"
				      ],
				      "WF": [
				        "asse"
				      ],
				      "WS": [
				        "asse"
				      ],
				      "YE": [
				        "euwe",
				        "euno"
				      ],
				      "YT": [
				        "euwe",
				        "euno"
				      ],
				      "ZA": [
				        "zano"
				      ],
				      "ZM": [
				        "euwe",
				        "euno"
				      ],
				      "ZW": [
				        "euwe",
				        "euno"
				      ],
				      "Continent-EU": [
				        "euwe",
				        "euno"
				      ],
				      "Continent-AF": [
				        "zano"
				      ],
				      "Continent-NA": [
				        "usea2",
				        "uswe"
				      ],
				      "Continent-SA": [
				        "brso"
				      ],
				      "Continent-OC": [
				        "ause",
				        "auea"
				      ],
				      "Continent-AS": [
				        "ause",
				        "auea"
				      ]
				    },
				    "pccUrl": "https://api.pstnhub.microsoft.com/v1/ngc/callnotification",
				    "ccUrl": "https://api3.cc.skype.com/conv/",
				    "Flighting": {
				      "PccUrl": "https://api.pstnhub.microsoft.com/v1/ngc/callnotification",
				      "CcUrl": "https://api3.cc.skype.com/conv/",
				      "IsDefault": true
				    }
				  },
				  "RichNotifications": {
				    "BlockedTelemetryColumns": [
				      "FeatureName",
				      "Password"
				    ]
				  },
				  "S4L": {
				    "unsafeTraceAreas": [
				      136,
				      252
				    ]
				  },
				  "S4L_Caap": {
				    "suggestions": {
				      "enabled": false,
				      "enableSuggestionsV2": false,
				      "suggestionIdTelemetryEnabled": true
				    },
				    "adaptiveCards": {
				      "enableSharing": false,
				      "imagePrefetchEnabled": true,
				      "placeholderLoadingTimeout": 1000,
				      "attributionAssets": [
				        {
				          "name": "Bing API",
				          "asset": ""
				        },
				        {
				          "name": "Bing",
				          "asset": ""
				        }
				      ]
				    },
				    "adaptiveCardAttributionAssets": [
				      {
				        "name": "Bing API",
				        "asset": ""
				      },
				      {
				        "name": "Bing",
				        "asset": ""
				      }
				    ]
				  },
				  "S4L_CMC": {
				    "createTranslatedChatEnabled": false,
				    "callTranslatorBotConfig": {
				      "languageSupport": {
				        "speech": [
				          "ar-SA",
				          "bg-BG",
				          "ca-ES",
				          "zh-CN",
				          "zh-TW",
				          "hr-HR",
				          "cs-CZ",
				          "da-DK",
				          "nl-NL",
				          "de-DE",
				          "el-GR",
				          "en-GB",
				          "en-US",
				          "es-ES",
				          "es-MX",
				          "et-EE",
				          "fi-FI",
				          "fr-CA",
				          "fr-FR",
				          "he-IL",
				          "hi-IN",
				          "hu-HU",
				          "id-ID",
				          "it-IT",
				          "ja-JP",
				          "ko-KR",
				          "lt-LT",
				          "lv-LV",
				          "ms-MY",
				          "nb-NO",
				          "pl-PL",
				          "pt-PT",
				          "pt-BR",
				          "ro-RO",
				          "ru-RU",
				          "sk-SK",
				          "sl-SI",
				          "sv-SE",
				          "th-TH",
				          "tr-TR",
				          "uk-UA",
				          "vi-VN"
				        ],
				        "tts": [
				          "ar-SA",
				          "bg-BG",
				          "ca-ES",
				          "zh-CN",
				          "zh-TW",
				          "hr-HR",
				          "cs-CZ",
				          "da-DK",
				          "nl-NL",
				          "de-DE",
				          "el-GR",
				          "en-GB",
				          "en-US",
				          "es-ES",
				          "es-MX",
				          "et-EE",
				          "fi-FI",
				          "fr-CA",
				          "fr-FR",
				          "he-IL",
				          "hi-IN",
				          "hu-HU",
				          "id-ID",
				          "it-IT",
				          "ja-JP",
				          "ko-KR",
				          "lt-LT",
				          "lv-LV",
				          "ms-MY",
				          "nb-NO",
				          "pl-PL",
				          "pt-PT",
				          "pt-BR",
				          "ro-RO",
				          "ru-RU",
				          "sk-SK",
				          "sl-SI",
				          "sv-SE",
				          "th-TH",
				          "tr-TR",
				          "uk-UA",
				          "vi-VN"
				        ]
				      }
				    },
				    "bingBackgrounds": {
				      "enabled": true,
				      "enableDataChannel": false,
				      "enableRoster": true,
				      "enableImageDownload": false,
				      "host": "https://www.bing.com",
				      "path": "/hp/api/v1/imagegallery?format=json&setmkt=[LOCALE]&today=1",
				      "pickImageBasedOnUserIdHash": false,
				      "showInSettings": false,
				      "showInCallFooter": true,
				      "iconCountInHeader": 2,
				      "useBingLogoInsteadOfSearchIcon": true,
				      "showBackgroundCaptions": true,
				      "tryOpenInAppBrowser": true,
				      "sendBackgroundInfoUpdates": false,
				      "throttleIntervalMs": 500,
				      "retryDataChannelSendOnError": true,
				      "retryDataChannelMaxNumber": 3,
				      "retryDataChannelDelayMs": 100
				    },
				    "enableUIToSelectSkypeOrPSTNContactToAddToGroupCall": true,
				    "callAudienceBotConfig": {
				      "enabledOneOnOneCall": false,
				      "enabledGroupCall": false,
				      "botMri": "28:9cd07db6-fab5-438c-8e34-44117fac7650",
				      "botMriFilter": "",
				      "minParticipantsOnCall": 10
				    },
				    "callGridViewBotConfig": {
				      "enabled": false,
				      "botMri": "28:ab5d1521-415b-4380-82e4-af803fb8bf2d",
				      "botMriFilter": "",
				      "minParticipantsOnCall": 5
				    },
				    "enableUFDQualityTelemetry": true,
				    "hideSnapshotButton": true,
				    "enableLabelsOnCallButtons": true,
				    "useAlternativeEndCallCreator": true,
				    "mediaRetryPolicy": {
				      "maxPostElapsedTime": 300000,
				      "maxRetriesDefault": 5,
				      "maxRetries": {
				        "postingService_postChatMessage": 1000000000,
				        "postingService_postChatMessageForeground": 1000000000,
				        "postingService_amsUpFullContent": 5,
				        "postingService_urlPreviewFetching": 3,
				        "postingService_updateChatMessageProperties": 3,
				        "downloadService_download": 10
				      },
				      "countLocalNetworkFailures": true
				    }
				  },
				  "S4L_Commerce": {
				    "purchaseConfirmation": {
				      "useDialogWithDisclaimers": true
				    },
				    "callFailure": {
				      "smsFailurePrompt": {
				        "enabled": false
				      },
				      "callFailurePrompt": {
				        "enabled": false,
				        "layoutOption": "creditOnly",
				        "copiesOption": "positive"
				      },
				      "tasterPostCall": {
				        "enabled": false
				      }
				    },
				    "callerIdCTA": {
				      "ignoreCallTerminatedReasons": [
				        14,
				        15,
				        16,
				        17,
				        18,
				        19,
				        20,
				        21,
				        22,
				        23,
				        33,
				        36,
				        37
				      ]
				    }
				  },
				  "S4L_Config": {
				    "contacts": {
				      "host": "https://edge.skype.com/pcs/"
				    },
				    "abch": {
				      "profileUrl": "https://pnv.skype.com/profile/"
				    },
				    "sms": {
				      "host": "https://consumer.entitlement.skype.com/",
				      "organizationId": "skype"
				    },
				    "urlPreview": {
				      "timeout": 5000
				    },
				    "endpointPresence": {
				      "inactiveEndpointTimeout": 0
				    },
				    "messageSearch": {
				      "host": "https://msgsearch.skype.com/v2/"
				    },
				    "chat": {
				      "validatePresenceMris": true,
				      "recreateEndpointOnSameLocationRedirect": true,
				      "serverSideEdits1to1": true
				    },
				    "presence": {
				      "forceFetchContactPresence": true,
				      "contact": {
				        "enableAllContactSubscription": true,
				        "maxSubscriptionLimit": 500,
				        "maxFetchLimit": 500,
				        "maxFetchRetries": 3
				      }
				    }
				  },
				  "S4L_Contacts": {
				    "sendLegacyInviteSfB": true,
				    "consumeLegacyInvites": true,
				    "enableCustomStatus": true,
				    "contactsFullSyncRefreshInHours": 120,
				    "enableInviteFreeQuarantineContactResync": true,
				    "enableAddRemoveContactOptions": true,
				    "enableProfileV2": true,
				    "enableEditSkypeContact": true,
				    "enableAddContactsFlow": true,
				    "enableInviteFree": true,
				    "enableGroupInviteFree": true,
				    "shortCircuitHashBatchSize": 200,
				    "shortCircuitSyncMatchLimit": 0,
				    "sendLegacyInvite": false,
				    "enableAddressBook": false,
				    "enableMacSyncAddressBook": false,
				    "enableNewContactsPanel": false,
				    "enableNewInviteShareUI": true,
				    "enableNewContactsIcon": true,
				    "enableGroupShareButtonInChat": false,
				    "enableNewSettings": false,
				    "enableSearchFeedback": false,
				    "userTrackingTelemetryEnabled": true,
				    "enableNewConnectionMessage": false,
				    "enableLoadingIndicatorInSearchInput": true,
				    "enableIOSAutoBuddy": false,
				    "enableShowSignedInAs": false,
				    "overrideWithAddressBookName": false,
				    "allowCallsFromContactsOnly": false,
				    "enableDeviceIdForShortcircuit": false,
				    "enableAddPstnContact": false,
				    "enableEditPSTNContact": false,
				    "enableMeControl": false,
				    "enableAvatarLoadErrorTracking": false
				  },
				  "S4L_Cortana": {
				    "clearSuggestionsConsentEnabled": true,
				    "inContextEnabled": false,
				    "enabled": false,
				    "suggestionsConsentEnabled": false
				  },
				  "S4L_Engagement": {
				    "engagementMessagesQueue": {
				      "enabled": true,
				      "refreshTime": 60000
				    },
				    "clientTriggeredEngagement": {
				      "enabled": true,
				      "campaignIdFiltering": {
				        "enabled": true,
				        "campaignIds": "test-scenario_engagementapi"
				      }
				    },
				    "engagementApiClient": {
				      "enabled": true,
				      "engagementApiHostPath": "https://engagementapi.skype.com/v1",
				      "excludedCampaignIds": [
				        "test-scenario_engagementapi",
				        "skype-sms-connect",
				        "skype-insiders-tou",
				        "onboardinguploadavatar",
				        "rou-insiderbuildquality",
				        "readreceiptsannouncementclient"
				      ],
				      "requestRetries": 3
				    },
				    "enableNoticeMessageSubscription": false,
				    "enabledNoticeMessageContentTypes": [],
				    "noticeDefaultTimeoutSeconds": 2419200,
				    "popCardDefaultTimeoutSeconds": 2419200,
				    "maxPopCardBulkSize": 10,
				    "maxNoticeBulkSize": 20,
				    "enableExternalBrowserLinkOpen": true,
				    "enableInAppBrowserLinkOpen": true,
				    "engagementUserTagging": {
				      "enabled": false,
				      "maxDurationInSeconds": 3600
				    },
				    "engagementSenderIdentity": [
				      "28:concierge",
				      "28:concierge_df"
				    ],
				    "conciergeBlockedMessageTypes": [
				      "RichText",
				      "RichText/Media_FlikMsg",
				      "RichText/Media_Card"
				    ],
				    "notices": {
				      "enabled": false,
				      "defaultTimeoutSeconds": 2419200,
				      "enabledMessageContentTypes": [],
				      "maxBulkSize": 20,
				      "schemaVersion": [
				        1
				      ]
				    },
				    "popCards": {
				      "enabled": false,
				      "backButtonEnabled": true,
				      "defaultTimeoutSeconds": 2419200,
				      "maxBulkSize": 10,
				      "toggleCloseOnLeft": false,
				      "uiVersion": 1,
				      "escKeyEnabled": true,
				      "imagePreloadEnabled": true
				    },
				    "coachMarks": {
				      "enabled": false,
				      "forceDisplayEnabled": false,
				      "defaultTimeoutSeconds": 2419200,
				      "maxBulkSize": 10
				    },
				    "engagementOfflineTargetedPullSetting": {
				      "enabled": true
				    }
				  },
				  "S4L_Feedback": {
				    "inClientFeedback": {
				      "enabled": false
				    },
				    "serviceAlerts": {
				      "enabled": false
				    }
				  },
				  "S4L_Messaging": {
				    "enableMessageReactionsHints": false,
				    "messageReactionsHintsMaxShownTimes": 0,
				    "pesPickerCategoryOrder": [
				      "emoticon",
				      "gif",
				      "sticker"
				    ],
				    "enableComposerForAndroidBrowser": true,
				    "disableFoursquareApi": true,
				    "composerNewFlagCaching": true,
				    "enableFileNotAvailableHandler": true,
				    "enableAllArchived": true,
				    "enableArchivedChatAnnotation": false,
				    "enableContactShareDragAndDrop": true,
				    "enableFullResolutionImageDownload": false,
				    "useSmsThreadsFor2way": true,
				    "enableSmsGroupedConversations": true,
				    "limitForFilePicker": 10,
				    "enableReactionNotifications": true,
				    "enableShareMediaPreview": true,
				    "bingPlacesAppId": "D41D8CD98F00B204E9800998ECF8427E1FBE79C2",
				    "enableLastMessageAuthorAvatarOverGroupIcon": true,
				    "enableLastMessageAuthorAvatarDefaultSettingOn": true,
				    "enableReadReceipts": true,
				    "readReceiptsAllowedLieTime": 60,
				    "customReactionsPanelExperimentIcon": true
				  },
				  "S4L_Onboarding": {
				    "contactInviteHeaderVariant": 3,
				    "showPrivacyButtonWithCookieLabel": true,
				    "newChatCopyVariant": 2,
				    "hideCortanaFromFRE": true
				  },
				  "S4L_Search": {
				    "hideInactivePublicDirectoryResults": true,
				    "enableNewDesktopSearch": true,
				    "enableTabFilters": true,
				    "enableDesktopSearchDebounce": true,
				    "preMountSearch": true,
				    "enableSplitPolicySettings": true,
				    "enableFallbackLinkDirectorySearch": true,
				    "enableSearchPerfBoost": true,
				    "enableUnifyHubSearch": true,
				    "enableSearchConfigImprovements": true,
				    "seeMorePublicDirectoryResults": true
				  },
				  "S4L_SISU": {
				    "aadLoginEnabled": false
				  },
				  "S4L_UI": {
				    "systemThemeEnabled": true,
				    "enableWebFooterPreviewBadge": false,
				    "sxAnimationsEnabled": true,
				    "showIncomingAlertsForAccessibility": true
				  },
				  "SCT": {
				    "Priority": {
				      "baca4c4fb3c842318f5c83f97f9553df": {
				        "Default": 0
				      }
				    },
				    "UseNewSdk": false,
				    "UseNewSdk2": true,
				    "PauseInBackground": false,
				    "SendFrequency": {
				      "act_stats": 3600
				    }
				  },
				  "Segmentation": {
				    "TelemetryRegion": "ROW",
				    "M365InnerRing": "false",
				    "TeamsRing": "general",
				    "IdentityType": "Consumer",
				    "Cloud": "Public",
				    "AudienceGroup": "general"
				  },
				  "SkylibInfrastructure": {
				    "enableSetMaxVideoChannels": true,
				    "enableSLAv2": true,
				    "enableLiveInterpretation": true,
				    "enableAddBroadcastModality": false,
				    "enablePublishState": true,
				    "enableMeetingSettings": true,
				    "enableGetAllParticipants": true,
				    "enableSearchParticipants": true,
				    "enableMusicOnHoldV2": true,
				    "enableUnrestrictingAttendees": true,
				    "enableSpotlight": true,
				    "enableAttendeeRestrictions": true,
				    "enableSafeTransfer": true,
				    "enableRingBasedRouting": true,
				    "enableCallMergeParticipants": true,
				    "enableCallMergeWithPickupCode": true,
				    "enablePano": true,
				    "enableSendMediaModalities": true,
				    "enablePreheat": true,
				    "enableCCWM": true
				  },
				  "SkypeAudioLibrary": {
				    "ECS_ADSP_VQE_enableDynamicMicChannelSelection": "false",
				    "UseClockRateForCNSupport": "true",
				    "QCAudioMinBw": "35000",
				    "QCAudioBwPercentage": "15",
				    "ECS_ADSP_Enable32kHzSupport": "true",
				    "Client_EnableMusicMode": "true",
				    "ECS_AudioPipeline_SoftRenderRestart": "false",
				    "DisableOpusStereoSupport": "true",
				    "EnableMusicModeRecv": "true",
				    "AecSwitchEnabled": "true",
				    "ECS_ADSP_VQE_MusicMode_MusicModeOverrideNoiseSuppression": "true",
				    "EnableSatinFB": true,
				    "ECS_ADSP_EnableG729": "1",
				    "JB_MaxStretchPercent": "50",
				    "JB_MaxCompressPercent": "25",
				    "JB_OpusDecSetting": "1",
				    "OpusEncInbandFecSetting": "10",
				    "ECS_ADSP_VQE_DisableTFNetDuringMicMute": "false",
				    "ECS_ADSP_VQE_DisableDeepAECDuringMicMute": "false",
				    "ECS_ADSP_VadTypeForSpeakWhileMutedUfd": "1",
				    "JB_MaxConferenceCNLevel": "89",
				    "UseHealedDataRatioNetworkClassifier": "true",
				    "AH_DisableSpecializedHealerNWQClassifier": "false",
				    "AH_HealedDataRatioNWClassifierThrs": "1070580402‬",
				    "CallerSatinEnabled": "true",
				    "CalleeSatinEnabled": "true",
				    "ECS_ADSP_SatinLowRateVersion": "4",
				    "ECS_ADSP_SatinToOpusSwitchBps": "20000",
				    "ECS_ADSP_OpusToSatinSwitchBps": "18000",
				    "SatinLRMinNumCores": "2",
				    "ECS_ADSP_Disable_CodecPitchUsage": "false",
				    "ECS_ADSP_Encode_EnableIncrementalEncode": "true",
				    "JB_MaxPayloadsToDropBeforeJBReset": "3000",
				    "ECS_AudioDL_Kingstone": "0",
				    "AH_FECControllerVersion": "1",
				    "AH_MRBLThresholdPercent": "1",
				    "ECS_ADSP_MultipleRedundancy_ReceiveMask": "16385",
				    "ECS_ADSP_ExternalFECRedundancyPercent": "50",
				    "AH_FECLatencyFrames": "10",
				    "ECS_ADSP_useRefactoredHealer": "1",
				    "ECS_ADSP_AH_NWQClassifier_JitterMsThreshold": "500",
				    "ECS_ADSP_AH_NWQClassifier_LossPercentThreshold": "20",
				    "ECS_ADSP_JB_ForceTransportMode": "1",
				    "ECS_ADSP_JB_MinDelay_Ms": "20",
				    "ECS_ADSP_JB_Delay_Margin_Ms": "60",
				    "ECS_ADSP_JB_Symmetric_Delay_Margin_Action": "0",
				    "ECS_ADSP_AH_Disable_PerFrame_CN_Flag": "1",
				    "ECS_ADSP_ASRC_ASNK_RaiseUfdUponStreamStartFail": "1",
				    "BandwidthDistributionType": "1",
				    "ECS_ADSP_Enable_LBRR_FEC_Allocation_QC": "25"
				  },
				  "SkypeBilling": {
				    "consumer-entitlement": {
				      "groups": {
				        "calling": [
				          "plan",
				          "package"
				        ],
				        "online-numbers": [
				          "skypein",
				          "skypein2"
				        ],
				        "personal-expressions": [
				          "moiji"
				        ]
				      }
				    }
				  },
				  "SkypeCalling": {
				    "enableWatermark": true,
				    "addResponseCodeToMetadata": true,
				    "enableAggregatedCallEndResponse": true,
				    "sendRejectOnMediaError": true,
				    "setStatusListenerBeforeReadingProperties": false,
				    "enableGlobalDeferHandler": true,
				    "enableMergeParticipantLegsBatchSupport": true,
				    "enablePluginlessCallParticipantRaiseChangeDeferred": true,
				    "electronParticipantShouldRaiseChangeBeforeConstructed": false,
				    "enableSLAv2": true,
				    "enableBatchedCallMemberCountChange": true,
				    "enableConvModalityChanges": true,
				    "enableErrorCodeImprovementsForNetworkFailures": true,
				    "enableSlowedDownSpeakerChangeEvents": true,
				    "enableStaging": true,
				    "enableAddParticipantPromiseOptimization": true,
				    "enableInCallSessionTelemetry": true,
				    "addStackErrorToMetadata": true,
				    "reportPreviousErrorsForAbort": true,
				    "enableOperationIdempotency": true,
				    "enableShareVideoWithoutAudio": true,
				    "disableCallMemberCreationFromAwareness": true,
				    "enablePIILogging": true,
				    "useReplacementBatching": true,
				    "nativeAdmitRejectionAsTransactionEnd": true,
				    "webAdmitRejectionAsTransactionEnd": true,
				    "enableLeavePerfImprovements": true,
				    "enableJoinPerfImprovements": true,
				    "enableMusicOnHoldV2": true,
				    "removeTransferQueue": true,
				    "highVolumeHttpRequests": [
				      "GET-Subscribe",
				      "POST-UpdateEndpointState",
				      "GET-SessionTicket",
				      "POST-SubscribeToConversation",
				      "PUT-UpdateEndpointMetaData",
				      "POST-CallUpdateKeepAlive",
				      "POST-CreateCallWithoutModality",
				      "POST-UpdateNotificationLinks",
				      "POST-LogUpload",
				      "POST-CallUpdateUrl",
				      "POST-MediaRenegotiationOffer",
				      "POST-MediaRenegotiationAnswerAck",
				      "POST-MediaRenegotiationAnswer"
				    ],
				    "enableNudgeWithSubscribeCaller": true,
				    "enableNudgeWithSubscribeCallee": true,
				    "enablePartlyExclusiveOperations": true,
				    "enableEncryptedHttp": false,
				    "enableEncryptedHttpForBroker": false,
				    "enableNewTransportStack": true,
				    "csaTimeoutConfiguration": {
				      "httpConnectionHedgingTimeoutInMs": 4000,
				      "httpConnectionHedgedRetryTimeoutInMs": 6000,
				      "httpHedgedRequestTransportForkingDelayInMs": 1000,
				      "udpConnectionHedgingTimeoutInMs": 1000,
				      "udpCanaryTimeoutMs": 2000
				    },
				    "mcr": {
				      "enabled": false,
				      "serviceFqdn": "https://api.mcr.skype.com",
				      "getMissedCallsUrl": "/clients/v1/users/skype/%destinationId%/missed-calls?anchor=",
				      "markReadStatusUrl": "/clients/v1/users/skype/%destinationId%/missed-calls/%anchor%/read-status?value=read"
				    },
				    "enableThirdPartyCallControl": true,
				    "pstnContentPayload": true,
				    "enableDeltaRoster": true,
				    "enableDeltaRosterWeb": true,
				    "enableDeltaRosterOneToOne": false,
				    "renegotiateVideoChannels": true,
				    "handleUnmuteMuteFromResponse": true,
				    "mediaConfiguration_TransportVersion": "4",
				    "serverMuteUnmute": true,
				    "brokerExclusively": false,
				    "ngIncoming": {
				      "isBrokerEnabled": true,
				      "isUdpCanaryEnabled": true
				    },
				    "ngOutgoing": {
				      "isBrokerEnabled": true,
				      "isEmergencyCallingEnabled": true
				    },
				    "mediaConfiguration_EnableOPUS": "true",
				    "overrideDisplayName": true,
				    "conversationServiceUrl": "https://api.flightproxy.skype.com/api/v2/cpconv",
				    "callControllerServiceUrl": "https://api3.cc.skype.com",
				    "udpTransportUrl": "udp://api.flightproxy.skype.com:3478",
				    "keyDistributionUrl": "https://api.flightproxy.skype.com/api/v2/cp/api3.cc.skype.com/kd/",
				    "EarlyRinging": 3,
				    "udpSignalingFastTimeoutMs": 1500,
				    "udpSignalingRetransmitTimeoutMs": 600,
				    "udpSignalingRetransmitCount": 2,
				    "udpSignalingMaxPacketSize": 1470,
				    "csaCallModalityEventPrioBoost": 1,
				    "cacheTrouterResponses": true,
				    "autoJoinOnRedirect": true,
				    "enableGroupCallEventMessagesOnService": true,
				    "p2pForkDelayInMs": -1,
				    "csaHttpPrioBoost": 1,
				    "csaVideoPrioBoost": 1,
				    "enableUdpFragmentation": true,
				    "enableUdpKeepAlive": true,
				    "enableDnsCache": false,
				    "enableUdpAlways": true,
				    "useDisplayNameFromAttach": true,
				    "negotiateAppSharingAlwaysForGroupCalls": true,
				    "supportCompressedTrouterPayload": true,
				    "allowBrokerSubscribeBatching": true,
				    "disableForwardingTimerOnClient": true,
				    "mediaConfiguration_IceClientVersion": "6",
				    "mediaConfiguration_SimulateReinviteEnabled": "1",
				    "mediaConfiguration_ContactServerTimeoutIncrement": "0",
				    "mediaConfiguration_DisabledPipes": "2",
				    "enableCallMerge": true,
				    "mediaConfiguration_EnableH264AVC": "1",
				    "mediaConfiguration_EnableRtx": "1",
				    "mediaConfiguration_DisableVC1": "1",
				    "mediaConfiguration_EnableAVMultiplexing": "1"
				  },
				  "SkypeEngagement": {
				    "experiments": {
				      "ukraine-donation-free-calls-sunset-campaign": "ukraine-donation-free-calls-sunset-campaign-varianta",
				      "friday-mailing-bot-message-junethrid": "friday-mailing-bot-message-junethrid-varianta",
				      "skypeunifiedipadinsider": "skypeunifiedipadinsider-varianta",
				      "ukraine-donation-campaign": "ukraine-donation-campaign-varianta",
				      "engagementbot-test01": "test-chatservicerichtextengagementbot-engagementbotmessage",
				      "silent-push-notif": "silent-push-notif-varianta",
				      "ukraine-pstn-client-notification": "ukraine-pstn-client-notification-varianta",
				      "ukraine-pstn-calls-android": "ukraine-pstn-calls-android-varianta",
				      "ukraine-pstn-calls-ios": "ukraine-pstn-calls-ios-varianta",
				      "churn-busters-weekly-ios": "churn-busters-weekly-ios-variantb",
				      "churn-busters-weekly-android": "churn-busters-weekly-android-variantj",
				      "churn-busters-weekly-msix": "control-churn-busters-weekly-msix",
				      "unified-ipad-after": "unified-ipad-after-varianta",
				      "unified-ipad": "unified-ipad-varianta",
				      "ndi-survey": "ndi-survey-varianta",
				      "decreasing-app-frequency-2": "decreasing-app-frequency-2-background-replace",
				      "msa-legal-update-june": "msa-legal-update-june-varianta",
				      "cmrc-orderdeliverycredit": "cmrc-orderdeliverycredit-notice-callspanel",
				      "welcomeemail": "welcomeemail-varianta",
				      "missed-call-reminder-push": "missedcallreminder-chat",
				      "first-cmrc-use-your-credit": "use-your-credit-didyouknow",
				      "cmrc-use-your-credit": "use-your-credit-remaining",
				      "missedchatreminderemailpublic": "missedchatreminderemailpublic-newfooteraugust2019",
				      "nps-web": "skypenpsweb-varianta",
				      "nps-electron": "nps-electron-popcard-b",
				      "missedcallreminderemailpublic": "missedcallreminderemailpublic-newfooteraugust2019",
				      "stepan-campaign-demo234": "stepanscampaign-notice",
				      "publicmissedchatreminder": "publicmissedchatreminder-speechbubble",
				      "gdpr-export-failure": "gdpr-export-failure-a",
				      "gdpr-export-success": "gdpr-export-success-a",
				      "secondstrike": "secondstrike-varianta",
				      "firststrike": "firststrike-varianta",
				      "highlightsdeprecation": "highlightsdeprecation-informational",
				      "nps-uwp-rn": "nps-uwprn-a",
				      "dogfood-xcards-test": "dogfood-xcards-test-xcard-a",
				      "cortanaoptin": "control-cortanaoptin",
				      "contactsyncnotification": "contactsyncnotification-notice-varianta",
				      "nps-mobile": "nps-mobile-c",
				      "fraud_notification-partial_block": "fraud-partial-block-generic"
				    }
				  },
				  "SkypeFeedbackAndSupport": {
				    "showChatWithAgentButton": false
				  },
				  "SkypeiOS": {
				    "improvedBotDiscoverabilityEnabled": true,
				    "pushVerificationEnabled": true,
				    "pushVerificationDelayMs": 0,
				    "pushVerificationServiceURL": "https://skype-ncls-prod.trafficmanager.net/v1/closedloop"
				  },
				  "SkypeM2": {
				    "SamplingRates": {
				      "log_chat_service_send_message": 5,
				      "log_chat_service_network_failures": 1
				    },
				    "autoStart": {
				      "isEnabled": true
				    },
				    "Telemetry": {
				      "log_message_end_to_end_delay": 1,
				      "log_chat_service_send_message": 1,
				      "log_chat_service_network_failures": 1
				    }
				  },
				  "SkypeMediaIntelligence": {
				    "enabled": false,
				    "Enabled": false
				  },
				  "SkypeMediaStack": {
				    "ConfCallEnableSRTPV2ForCaller": 1,
				    "ConfCallEnableSRTPV2ForCallee": 1,
				    "ParseXMediaBWConf": 0,
				    "P2PEnableSRTPV2ForCaller": 1,
				    "P2PEnableSRTPV2ForCallee": 1,
				    "ClientIgnoreRtxParticipatForRR_SRCalculation": "true",
				    "SlowedActiveTalkerListEnabled": true,
				    "ClientEnableRTCPReductionInNonRootVideoChannels": "true",
				    "RealtimeDataSourceSettings": {
				      "devices": {
				        "13": {
				          "ladder": [
				            5000,
				            10000,
				            26000,
				            26000,
				            26000,
				            26000,
				            26000
				          ],
				          "ladderStatic": [
				            3000,
				            5000,
				            26000,
				            26000,
				            26000,
				            26000,
				            26000
				          ]
				        }
				      }
				    },
				    "DynamicBitrateDataChannel": true,
				    "EnableRemoteUserEvents": true,
				    "UseRTDnsResolver": true,
				    "RemoveFromGroupIfTheChannelIsDisabled": false,
				    "QcBandwidthCap": 4000000,
				    "EnableBwcForVbss": "1",
				    "MaxTimeInRBQueue": 3500,
				    "mediaConfiguration_UseVideoPortRangeWhenBundled": 0
				  },
				  "SkypePersonalization": {
				    "pes_config": "https://static-asm.secure.skypeassets.com/pes/v1/configs/56ba0c2ad23a48d7ba150cbece4e960e/views/default"
				  },
				  "SkypeResourceManager": {
				    "PoliciedLossBackoff": {
				      "MaxLTMinorReadjusts": 5,
				      "LongCallThSecs": 150,
				      "RampupRate": 0.2,
				      "RampupSettingsTune": 0.3,
				      "PlbSettingsTune": 0.55,
				      "TimeToRampUp": 7000,
				      "OwdSmoothFactor": 0.005,
				      "SwitchOnUkfEstConfFactor": 0.04,
				      "LongCallThSecs,": 150,
				      "ProbDropOnGoodCall": 0.01,
				      "LossRateLtCap": 0.1,
				      "LossRateLtFloor": 0.3,
				      "HighBwConfBoost": true,
				      "PacketLossThreshold": 0.16,
				      "TimeToTriggerPolicy": 6000,
				      "MaxRampupAttempts": 40,
				      "PercentTimeRatioDisable": 0.15,
				      "SafetyMargin": 0.12,
				      "MinLossDrop": 0.5,
				      "OwdThreshold": 80,
				      "RampupLossDisable": 0.4,
				      "RampupLossEnable": 0.25,
				      "Enabled": true,
				      "PercentTimeRatioTrigger": 0.2,
				      "MaxConfidence": 0.85,
				      "RampupLossDrop": 0.45,
				      "DetectBWFloor": 28000,
				      "MinBWFloor": 28000,
				      "MinGoodCallDuration": 60000,
				      "MaxGoodCallLossBackoffPercent": 1
				    },
				    "Ukf1": {
				      "ProcessReorderPacketsOnNonRealTimeOnly": true,
				      "HandleReordering": true,
				      "HandleReorderingDC": true,
				      "useMinRTTReroute": true,
				      "MinRTTSafeRTTAdjustFactor": 7,
				      "MinRTTSafeRTTAdjustFactorPP": 1.5,
				      "LossDelayDcSlowRise": 0.01,
				      "FastAdjustRecvMaxOnChoke": 0.05,
				      "EnableRTTAgeforDC": true,
				      "AdjustCovOnUnderUtilize": false,
				      "AggrUkfSecurityGain": 0.15,
				      "EmergencyLossRate": 0.01,
				      "audioAbsentDelayFactor": 1.5,
				      "LossRttDcSlowRise": 0.02,
				      "AvgMinRttFactor": 0.2,
				      "MinRttFastRiseFactor": 1.4,
				      "UseObservedResidualDelay": true,
				      "pp_samples_since_update_th": 63
				    },
				    "QCLowBwMinExpThreshold": "32000",
				    "RateController": {
				      "MinPeakTimeRampupTime": 3,
				      "MinPeakTimeRampdownTime": 4,
				      "PeakEstimator": {
				        "PacketTrainTauTMaxGap": 2,
				        "PTrainMinDelay": true,
				        "AdaptOnZeroMinDelay": true,
				        "HighRWeight": 0.03,
				        "LowRWeight": 0.3,
				        "UseUsAccuracy": true,
				        "TauRUsOffset": 300,
				        "PacketTrainZeroTauR": true,
				        "TauTModelPreCheck": true,
				        "UseMinDelay": true,
				        "LowBwQNoise": 150
				      },
				      "SMConsistentLossFactor": 0.08,
				      "UkfSmoothDrops": false,
				      "UkfModeKfwFactor": 0.55,
				      "BwOnChokeFactor": 0.15,
				      "BackOffFloor": 32,
				      "SlowModePeriodEarlyExit": 20,
				      "NoCongestionOffset": 70,
				      "CongestionSign": 0.3,
				      "NoCongestionFactor": 2,
				      "NoCongestionLowLossFactor": 1.25,
				      "LowCongestionLowLossFactor": 1.15,
				      "NonCongestionLossDiscountEnabled": false,
				      "NonCongestionLossFactor": 0.6,
				      "AggressiveRecvUtilFactor": 0.5
				    },
				    "BurstDelivery": {
				      "PeakEstToUkf1Factor": 1.15,
				      "PeakEstRampDown": 0.01,
				      "BurstDeliveryProbThPeakEst": 0.8
				    },
				    "StatConfig": {
				      "TimeBasedLossDelayFactor": 0.7,
				      "StartOfCallStatTime": 10
				    },
				    "OwdBackoff": {
				      "ReduceUkfEstOnly": true,
				      "Weight": 0.4,
				      "MinOwd": 0.3,
				      "RecvStability": 150,
				      "UseTauSmoothRate": true,
				      "Sensitivity": 1
				    },
				    "SideTrafficMaxHistoryMs": 2000,
				    "ArrivalStream": {
				      "ApplySideTrafficRate": 400,
				      "MinSTRateFactor": 0.1,
				      "STSmoothFactor": 0.02,
				      "AggrScale": 1.7,
				      "WeightLargePackets": 0.01,
				      "IgnorePause": 0.5
				    },
				    "RampFromHistory": {
				      "EnableUplinkHistUpdateOnLowUtil": true,
				      "AfterInit": true,
				      "SeparateGvcHistory": true,
				      "Enabled": true,
				      "UsePeerInfoExchangeBw": true,
				      "LocalUplinkHistoryCap": 1500,
				      "LocalDownlinkHistoryCap": 1500
				    },
				    "BweRampup": {
				      "CongestionLossProbTh": 0.65,
				      "PersistentLossFactor": 0.07,
				      "RecentLossDeviationAllowed": 2.1,
				      "AvgLossDeviationAllowed": 1.4,
				      "MaxEstRampupPersistLoss": 250000,
				      "UncappedEstRampupInterval": 0.6,
				      "RampupIncrementStep": 1.12,
				      "EstFactorNoLoss": 1.2,
				      "UncappedEstRampupIntervalAudioOnly": 1,
				      "MaxEstRampup": 187500
				    },
				    "ArrivalOk": {
				      "RecvMaxNonCongestionLoss": true,
				      "CongestionLossProbTh": 0.5,
				      "HighNonCongestionLoss": 0.75,
				      "NonCongestionLossInc": 0.12
				    },
				    "ReceiveRateEstCap": {
				      "AggressiveFactor": 2.2,
				      "Factor": 2
				    },
				    "TcpFighter": {
				      "Enabled": true,
				      "MaxBwRatio": 0.15,
				      "LowBwMaxRatio": 0.45,
				      "VeryLowBwMaxRatio": 0.5,
				      "Beta": 0.55,
				      "LowBwBeta": 0.35,
				      "VeryLowBwBeta": 0.25,
				      "DropByLossRate": true,
				      "LowNetworkQTh": 0.15,
				      "AvgLossThreshold": 0.12,
				      "RecentLossThreshold": 0.19
				    },
				    "VideoExperience": {
				      "ExperienceTuning": {
				        "LowBandwidth": 800,
				        "VeryLowBandwidth": 300,
				        "HighPacketLoss": 0.05
				      }
				    },
				    "AudioExperience": {
				      "ExperienceTuning": {
				        "LowBandwidth": 90,
				        "VeryLowBandwidth": 50,
				        "HighPacketLoss": 0.05
				      }
				    },
				    "RttResetOnNoUpdate": true,
				    "ReorderBufferEnableLastPacketSeen": true,
				    "BandwidthCaps": [
				      {
				        "network": -1,
				        "uplink": 500000,
				        "downlink": 500000
				      }
				    ],
				    "QcTriggerProbeThreshold": 70,
				    "QcDesiredQueueLen": 180,
				    "QcProbeIntervalHighBw": 3000,
				    "QcProbeIntervalLowBw": 1500,
				    "QcProbeTrafficPercentage": 85,
				    "EnableForGVC": "on",
				    "QcEnableRtcpProbeGVC": 1,
				    "QcEnableRtcpProbeP2P": 1,
				    "Ukf2": {
				      "WeightByNetworkQueueUsage": true,
				      "DcClip": true
				    },
				    "UplinkHistogramCap": {
				      "UseUkf": true,
				      "SlashingCountThreshold": 150,
				      "Enabled": true,
				      "InitializationPower": 256,
				      "CapPercentile": 0.25
				    },
				    "HistoryPercentile": 0.4,
				    "RMExchangeCachedBw": 1,
				    "BandwidthEstimator": {},
				    "RMReceiveQueueCompRefLossFix": 1,
				    "RMReceiveQueueCompRefLossFixGvc": 1,
				    "ReceiveQueueRtxTypeMask": "21",
				    "ReceiveQueueRtxVbssTypeMask": "21",
				    "RMReceiveQueueRtxSuppressPLI": "1",
				    "RMReceiveQueueRecoveryReqFix": "1",
				    "EnableOutOfOrderTolerance": "1",
				    "ReceiveQueueRtx": "1",
				    "ReceiveQueueRtxNonKeyPercent": "100",
				    "ReceiveQueueRtxVbssNonKeyPercent": "100",
				    "DynamicCapPreciseDecodeTime": 1,
				    "QCLowBwMinExpForVideo": "15000",
				    "FastBwFeedbackIntervalMs": 150,
				    "LossTrackerVersion": 1,
				    "LossIncreaseEnabled": false,
				    "EventPriority": {
				      "RMHistogram": 0
				    },
				    "DataRvCapInCall": 125,
				    "ThirdGenAlloc": {
				      "ConcurrentFTs": 0
				    },
				    "LyncRm": "on",
				    "AggressiveUKF": true
				  },
				  "SkypeRootTools": {
				    "RootTools": {
				      "Regular": {
				        "Proxy_PAC_HostArgument": "teams.microsoft.com",
				        "GenericTcpConnect_Version": 3,
				        "Proxy_RespectSystemProxy": 1,
				        "Proxy_ManagerVersion": 2
				      }
				    },
				    "ULBaseline": {
				      "killswitch": {
				        "blacklist": [
				          {
				            "namespace": "SkypeAudioLibrary",
				            "experiment": "CreateProbeDeviceFailures"
				          },
				          {
				            "namespace": "SkypeVideoLibrary",
				            "experiment": "Capability DDL iphone #1840981"
				          },
				          {
				            "namespace": "SkypeVideoLibrary",
				            "experiment": "Capability DDL mac #1840981"
				          },
				          {
				            "namespace": "SkypeAudioLibrary",
				            "experiment": "CreateProbeDeviceFailures_2"
				          },
				          {
				            "namespace": "SkypeAudioLibrary",
				            "experiment": "Per-packet Trace collection for S4L 1-1"
				          }
				        ]
				      },
				      "writeSafeLogs": true,
				      "configPaths": [
				        {
				          "ns": "AsyncMediaClient",
				          "key": "ULLogUpload"
				        },
				        {
				          "ns": "teamsddl",
				          "key": "ULLogUpload"
				        },
				        {
				          "ns": "Notifications",
				          "key": "ULLogUpload"
				        },
				        {
				          "ns": "SkypeAudioLibrary",
				          "key": "ULLogUpload"
				        },
				        {
				          "ns": "SkypeCallQuality",
				          "key": "LiveDebugging"
				        },
				        {
				          "ns": "SkypeCalling",
				          "key": "ULLogUpload"
				        },
				        {
				          "ns": "SkypeRealTimeMedia",
				          "key": "ULLogUpload"
				        },
				        {
				          "ns": "SkypeMediaStack",
				          "key": "ULLogUpload"
				        },
				        {
				          "ns": "SkypeResourceManager",
				          "key": "ULLogUpload"
				        },
				        {
				          "ns": "SkypeRootTools",
				          "key": "ULLogUpload"
				        },
				        {
				          "ns": "SkypeRootTools",
				          "key": "DDLTest"
				        },
				        {
				          "ns": "SkypeRootTools",
				          "key": "S4L_JS_Buffer"
				        },
				        {
				          "ns": "SkypeTransport",
				          "key": "ULLogUpload"
				        },
				        {
				          "ns": "SkypeVideoLibrary",
				          "key": "ULLogUpload"
				        },
				        {
				          "ns": "TrouterClientCorelib",
				          "key": "ULLogUpload"
				        },
				        {
				          "ns": "SkypeIoT",
				          "key": "ULLogUpload"
				        },
				        {
				          "ns": "MediaAgent",
				          "key": "ULLogUpload"
				        },
				        {
				          "ns": "S4L_CMC",
				          "key": "ULLogUpload"
				        },
				        {
				          "ns": "S4L_Telemetry",
				          "key": "ULLogUpload"
				        },
				        {
				          "ns": "SCT",
				          "key": "ULLogUpload"
				        },
				        {
				          "ns": "SkypeQualityController",
				          "key": "ULLogUpload"
				        },
				        {
				          "ns": "S4L_Feedback",
				          "key": "ULLogUpload"
				        },
				        {
				          "ns": "MDN_TRAP",
				          "key": "ULLogUpload"
				        },
				        {
				          "ns": "Identity",
				          "key": "ULLogUpload"
				        },
				        {
				          "ns": "RtcPalVideoConfiguration",
				          "key": "ULLogUpload"
				        },
				        {
				          "ns": "Broadcast",
				          "key": "ULLogUpload"
				        },
				        {
				          "ns": "S4L_SISU",
				          "key": "ULLogUpload"
				        },
				        {
				          "ns": "S4L_Messaging",
				          "key": "ULLogUpload"
				        },
				        {
				          "ns": "SkypeWebMedia",
				          "key": "ULLogUpload"
				        }
				      ],
				      "circularBuffer": {
				        "enabled": false
				      },
				      "logUpload": {
				        "maxSize": 204800,
				        "logFileReserves": [
				          {
				            "percent": 5,
				            "level": "WARN"
				          },
				          {
				            "percent": 2,
				            "level": "TRACE"
				          }
				        ]
				      }
				    }
				  },
				  "SkypeTeamsClientIOS": {
				    "cerberusContnuosAAiOS": true,
				    "platform": {
				      "appAcquisition": {
				        "enableSidePanel": true,
				        "enableChannelMeeting": true
				      },
				      "blockedApps": [
				        "6b9cc557-e24a-4744-a370-407e717f2195",
				        "16332d3e-5eef-4d71-80e6-4d5a86b7b822",
				        "8f79287d-5850-42f1-9af2-48ddf6ef89a8",
				        "7b0641d9-8e1f-4415-99da-c80f8c175c69",
				        "089d82a1-632c-4bb2-b307-23b8166b0113",
				        "2ccabd94-c7ca-4c99-94bb-356d98398409",
				        "acbf66b6-22ab-4e51-98d4-00bb91897116",
				        "829fa155-8058-4b1e-b43a-86efb74da5d4",
				        "4c4ec2e8-4a2c-4bce-8d8f-00fc664a4e5b",
				        "a99cb12c-d46a-4f7a-87c5-06b2da1cb746",
				        "6615e379-7eb9-4e65-afee-2c8a9322aa4b",
				        "c1de80e3-f0e4-4962-bcae-fa23e70366a5",
				        "b756a1a0-1b2f-42ff-90b5-b2a98281fc83",
				        "7a0c1d53-f647-4d76-ab2c-fbc0d73c8bb0",
				        "84c2de91-84e8-4bbf-b15d-9ef33245ad29",
				        "c447be50-d9a3-4c34-b6e4-15ad0ef542bd",
				        "44263ed4-f1ac-4e96-93aa-d24dd50459ea",
				        "b7b8b186-b39d-4028-ac91-84528eebc3e0",
				        "7fabc104-4759-437e-ac5c-9aba7f3a09af",
				        "46fae4d0-faf5-11e9-80f3-53ad33b77bce",
				        "a59fe11a-7ae8-4569-94d1-081c83ab59b6",
				        "effd9d69-e11a-497e-a405-ff79c024e973",
				        "5b876856-c90d-47f8-a6fc-8de780f76cc7",
				        "d7d081d4-d24e-4652-aea6-280db1fd2219",
				        "b8e32e5f-bad2-490b-9470-55d8917cf73a",
				        "9f859fc4-0b17-4bf7-abff-f50a73cbe5ab",
				        "7656ec6e-c63b-4571-8ab8-95d1c451d1e6",
				        "14072831-8a2a-4f76-9294-057bf0b42a68",
				        "a2be9b85-098e-4e62-b51f-756ae2f551a8",
				        "27a3e6d5-98b7-45f7-a04a-7dd7e19edebe",
				        "com.microsoft.teamspace.tab.files.sharepoint",
				        "2399aa4e-bba7-4993-a552-16781e510f76",
				        "eb6dada2-bc16-40fe-b9e9-0d0ab3916704",
				        "cd2d8695-bdc9-4d8e-9620-cc963ed81f41",
				        "83c83baa-0b22-4bc5-9a37-1d8e6ab6fd7b",
				        "3ae27f31-ceea-4d13-a212-cdc9d786eae1",
				        "36ae0e3d-3446-48d0-86cb-b8bde5265cd4",
				        "b712da79-73c8-4d56-8531-1e180c95e9d1",
				        "1a24a3a3-1fda-4f70-abee-40bba8c638e8",
				        "com.microsoft.teamspace.tab.file.staticviewer.excel",
				        "3ed5b337-c2c9-4d5d-b7b4-84ff09a8fc1c",
				        "17e00609-c03b-44e4-b516-fb2d2232e95d",
				        "86ce8ab3-7472-47ef-9cf5-7225ff0c77d5",
				        "9f1a4ae0-6ae2-475d-973d-c89687d03753",
				        "cc649732-0f1c-41be-bb52-fbeaab71c7cf",
				        "e1946271-e466-41f9-adba-c5bbe53e56a4",
				        "474c7f73-c3dd-4b94-96f0-23f7fa771cee",
				        "8bd0dbd9-defe-4a4a-aa75-0c3b5396cad2",
				        "0ec566bc-a37a-46ca-a252-54af50dfa86e",
				        "5fdd80e2-4d58-4c5c-ac85-356c1b2a0bba",
				        "5a0e35f9-d3c8-45b6-9dd9-983ab47f1b83",
				        "90a27c51-5c74-453b-944a-134ba86da790",
				        "7fceea0d-ed46-4394-876a-9b95b55be8e4",
				        "bce03b83-412b-4dfa-ae76-c9171a5f5ed7",
				        "d4460828-ddde-4619-b40b-39412667f7a3",
				        "bd9fb5cb-4d02-4cc6-a7f4-52a8a62d30b7",
				        "442cc7cc-4faa-469c-b8f8-581b2d5bd8aa",
				        "95e54205-5e03-45e7-abef-1e8a41374407",
				        "6eacb5f0-68b0-46f0-9507-9e906c6861fc",
				        "3e036580-07e4-11eb-abda-0962f34e6510",
				        "23a02895-ba8c-40e0-a274-ffa11fc9684f",
				        "2b58c90b-d22b-4b5a-8a1f-6f6e6f3a7e92",
				        "2d96b540-aa26-431b-bc31-222321c762e3",
				        "75d1c59c-8b16-462f-ae74-d98210a39258",
				        "75d3e61c-e5b7-45cc-9b2a-0f8c98a6b91b",
				        "7cd7b1f7-095d-4aaa-9d01-753a015f17b7",
				        "aa3abc6b-b10d-4f6d-b5e0-14af44fab745",
				        "4c0c1f9b-7500-4eac-8d48-3fffe69b3b91",
				        "3564714a-1e68-40c6-ba09-2e9eac549942",
				        "6d1f20e6-538e-4748-896a-1d7d5998d418",
				        "7439ed9e-8ef5-4525-ac80-21d84eb1f90e",
				        "28a06151-a6ba-4817-9ab4-454fb6e59cc6",
				        "f1a2add5-d007-4062-a10a-60f4ea29fdbc",
				        "205214d0-e04b-11e9-9332-5b5c97b60069",
				        "1eb81651-f5d3-4e95-bceb-5ae2ffffd00e",
				        "bf9c1c49-a529-451e-a81d-ac94cfdbec3e",
				        "com.microsoft.teamspace.tab.notes",
				        "b85718a3-6d15-4f59-8fad-b6809c6fc6a9",
				        "ca4b5141-5c46-47bc-a05e-2733d9bd69aa",
				        "5f56e504-48aa-46a0-bd6d-2231355b2830",
				        "00001016-de05-492e-9106-4828fc8a8687",
				        "25b07509-bc6a-4a53-b683-9beb24e55570",
				        "30e8c77f-acd9-453f-958a-82baf329c73d",
				        "com.microsoft.teamspace.tab.powerbi",
				        "com.microsoft.teamspace.tab.file.staticviewer.powerpoint",
				        "57799d60-92cd-40fd-8051-3570a1290828",
				        "65abccad-bf65-497c-8ea2-eec2036b6f13",
				        "a4b9907d-cff2-4771-91d5-30cb794f00c5",
				        "659243fc-ebc2-42fa-aa43-dfcad0f8bcd1",
				        "1d20e5e6-7310-4029-aa63-3efc9e84e926",
				        "2f285d77-896a-4c5f-901e-0902316003b5",
				        "c6462b50-a869-45e1-88b6-734c7087df25",
				        "4608dd75-e769-46f0-8f28-ac18c714cad1",
				        "29d59aa7-28cf-4460-a6be-918f4557e420",
				        "14510476-fa9d-4dad-add9-aa5975a60a8b",
				        "0fdcda7d-5ce6-41a0-b5a3-4fa867815487",
				        "38ff7ef9-c2ff-4a65-9774-a5d338ae708d",
				        "8c9f8e8e-fe2d-4542-84ab-1d30c4a735fc",
				        "7824020d-ce5a-420f-ab91-2dc72f27834a",
				        "3bf2e254-d6c9-4e0c-b269-1c80c1220dc4",
				        "7792759a-43e8-4dc8-9f55-e7b0382c4a67",
				        "1dc264f0-30a4-4585-9ed9-febabfa6fd7e",
				        "73e63b28-e6b1-48fe-9ca5-b6801b5bd4d5",
				        "bcb050bd-ad7e-4e0e-94a7-e38d7fa098c9",
				        "e946766a-060d-4b50-bc90-f8de7b48b184",
				        "effe13ef-00e2-4d55-a207-f2d9d1dd7263",
				        "def85aef-c838-4f6b-b76e-53292aaa43d9",
				        "37664cf9-dd77-4681-b286-430107bea7bf",
				        "32772d29-4df0-4c7d-bade-8f35fe9101a3",
				        "015bf4ec-bc37-4931-9862-ef8686da652b",
				        "1d192ad2-6590-4179-a088-daff383a52b5",
				        "62a00d05-797b-4e83-bf9c-8ea6b3163878",
				        "com.microsoft.teamspace.tab.file.staticviewer.visio",
				        "bae0fc3b-3f87-41d5-a144-02d536f827c3",
				        "51abb001-38d9-4d2a-a877-069e07099ad6",
				        "0924e969-85d8-4acb-8687-faacd6abd228",
				        "6f9f20ca-95d0-4534-8f23-b36ad7e3955a",
				        "com.microsoft.teamspace.tab.file.staticviewer.word",
				        "a671596c-9fb7-40ba-9915-c3420781b0db",
				        "bc4e7b4a-0ae5-49be-a56f-743e16aca230",
				        "8a1da635-7529-4456-b43a-56cbd865c3cf",
				        "39e837f8-e135-4130-94a2-ed89ac575cd1",
				        "88ffccc0-71cf-4451-8783-898b7b944814",
				        "3a54620f-98a1-4804-bcdc-fa7324d8fbd0",
				        "0d820ecd-def2-4297-adad-78056cde7c78",
				        "d7958adf-f419-46fa-941b-1b946497ef84",
				        "1c256a65-83a6-4b5c-9ccf-78f8afb6f1e8",
				        "3e0a4fec-499b-4138-8e7c-71a9d88a62ed"
				      ],
				      "enableACv2OAuthFlow": true,
				      "enableACv2SSOFlow": true,
				      "enableAuthenticationBlockUsageForAdaptiveCardsV2": true,
				      "authenticationBlockHonourTimeInMinutesForAdaptiveCardsV2": 360,
				      "resetSyncFlagsOnConflictError": true,
				      "appsWithMeetingApisPermissions": [
				        "9ae3d116-3feb-48c6-b3c4-b61dceb760af"
				      ],
				      "getMeetingDetailsJsApiEnabled": true,
				      "refactoredStageViewEnabled": true,
				      "sharedChannelSyncEnabled": true,
				      "genericAppShareEnabled": true,
				      "enableCollabCloudApis": true,
				      "collabCloudEndpointUrl": "https://teams.microsoft.com/api/platform",
				      "syncEntitlementsBeforeJITInstallation": true,
				      "InlineMediaPlaybackEnabled": true,
				      "enableRefreshForAdaptiveCardsOnClosingTaskModule": true,
				      "rscAuthorization": {
				        "enableGetMeetingsAPI": true
				      },
				      "reactiveMETray": true,
				      "enableAppInstallationForMessageExtensionAdaptiveCardsV2": true,
				      "extensibilityExternalAuthTimeoutInSec": 900,
				      "extensibilityExternalAuthEnabled": true,
				      "externalAuthPreferEphemeralSession": false,
				      "enableShareToStage": true,
				      "disableWebAppLoadCancellation": true,
				      "shouldSkipConfigTabsWebsiteURLCheckOniPad": true,
				      "platformiPadExperienceEnabled": true,
				      "enableCardActionInvokeComplianceData": true,
				      "blacklistedCEAppsInOneOnOneChat": [
				        "50f36183-1764-4d11-98a4-c1f9d1eaadfa",
				        "81fef3a6-72aa-4648-a763-de824aeafb7d"
				      ],
				      "blacklistedCEAppsInMeetingChat": [
				        "50f36183-1764-4d11-98a4-c1f9d1eaadfa",
				        "81fef3a6-72aa-4648-a763-de824aeafb7d"
				      ],
				      "blacklistedCEAppsInGroupChat": [],
				      "blacklistedCEAppsInChannel": [],
				      "stageViewEnabled": true,
				      "deepLinkExceptionApps": [
				        "0d820ecd-def2-4297-adad-78056cde7c78"
				      ],
				      "enableAdaptiveCardEmptyChoicesetFix": true,
				      "enableAdaptiveCardDirectorySearch": true,
				      "enableActionExecuteForMessageExtensionAdaptiveCards": true,
				      "enableRefreshForMessageExtensionAdaptiveCards": true,
				      "maxMemberCountForAdaptiveCardsAutomaticRefresh": 60,
				      "enableContextMenuForAdaptiveCards": true,
				      "jsonBasedStaticTabEnabled": true,
				      "inMeetingTabsWhitelistedApps": [
				        "81fef3a6-72aa-4648-a763-de824aeafb7d",
				        "67a33d8c-d6a8-4003-a32a-8a61e331d02d",
				        "6aa4a751-8a6a-429e-b924-1360ed272414",
				        "15e4734f-39d1-4e4e-8a04-867adaa7e609",
				        "5d70b04b-17bd-4b62-ab52-44f5fcf1eaba",
				        "6b4ac65a-764d-4021-bf3f-40cb2d137a33",
				        "f4ebba7b-f758-40e1-8b3a-e927603ab369",
				        "693aa4f0-e16c-11ea-ab9b-11514b3de7ae",
				        "82099dc9-b732-48d3-91bd-1b40f8919acd",
				        "377da6a7-efc3-4599-887a-1d3eda45120a",
				        "10abe1df-2ac5-4cdd-baaf-72b1cccca08c",
				        "ccfe5256-29b8-4cc2-95ed-6612c0e1b10d",
				        "0af388af-3bbb-4ecd-916d-304d75ea23dd",
				        "e8f06a4e-cefe-4b1e-a24b-c97bea471130",
				        "3e701664-cc46-49e4-b356-1a7ac6500998",
				        "7299e0d0-4865-4342-ab4d-74a206553d54",
				        "3ab6c134-f8ac-44d0-be3c-5b97aecec55b",
				        "c738b607-88dd-4f16-aefe-6a824c65d25d",
				        "6437ba58-d2f5-4f19-ab7d-ef63578fa040",
				        "f2125454-678c-4f97-90cc-dfe4742f4711",
				        "9767c4fd-7319-4d64-8b6a-941b02d11ffd",
				        "647624e1-056f-43cb-a112-b9bc64c81ef4",
				        "55BD7E37-C05E-44AD-B8C6-244B7223B92F",
				        "6291175d-3832-4c33-baea-10eb4b9ff1c4",
				        "1356036b-5fa7-42ce-8079-5741f2acfc5f",
				        "d6e4a9b6-646c-32fc-88ba-a6dd6150d1f7",
				        "adb3c870-c01c-11eb-a2cc-4dbd838985a1",
				        "dbac18d4-9154-46f1-9d03-620717fa47d4",
				        "18eb20ae-cd59-48c6-8060-fbe171a917e5",
				        "1542629c-01b3-4a6d-8f76-1938b779e48d",
				        "10a3a812-c72d-47d4-b9b5-6425c6fed158",
				        " 3586755a-4e4f-4ad2-8846-6f408ede3a19",
				        "b96db765-b9ef-43c7-a02d-fdfb973a6fe6",
				        "83e15843-4af6-4b33-bacc-d11827352c3e",
				        "db7832f4-7ead-41d4-ae33-a58096cf0c6d",
				        "com.microsoft.teamspace.tab.youtube",
				        "c7b89fc0-e91f-48c3-bb75-ea4951e498af",
				        "fbfc72f8-42a3-4b41-8a1e-025082355777",
				        "fbfc72f8-42a3-4b41-8a1e-025082355777",
				        "30b8d518-2535-4919-ab8b-d0fab193380f",
				        "d75e14a9-9bfd-43b4-8430-7264da3b6995",
				        "ffca97e5-0569-c88c-ac30-7c5717e2e5ae",
				        "272032ad-0c2e-4928-910e-5d52b19f70d5",
				        "68a8c89f-fa57-4a6a-9ab7-0a9e83c4b556",
				        "2d8e8042-66df-4605-8c3a-9ca8962f3e99",
				        "9ae3d116-3feb-48c6-b3c4-b61dceb760af",
				        "d863a24b-7cdd-46c9-8309-a15878f4f7bf",
				        "0e3bedea-4720-48b5-9e13-5a1ce1387d45",
				        "3227443e-0f19-4187-a886-4a112ddf3f56",
				        "c92c289e-ceb4-4755-819d-0d1dffdab6fa",
				        "ba4eda44-cd55-4e15-855c-0debafb0490b",
				        "80ac8832-83fd-4669-af2a-8e2d2979bea5",
				        "a803920d-84ff-4fa0-8f16-b547b7c027ef",
				        "96aa4c16-d788-42e0-a4f8-7701da30f437",
				        "dddf988d-00af-480f-b419-76a357a72460",
				        "0b48e71e-8f46-46d8-a545-608295f000ac",
				        "173a0e6d-74dd-4df3-97f8-118a27c20f5d",
				        "6fbeb90c-3d55-4bd5-82c4-bfe824be4300",
				        "a5711b63-5e70-4e4e-b040-0d714b64f684",
				        " d3a07709-eb0e-421c-8609-b61b0600e645",
				        "  f6671df0-1909-428c-91f7-1c42df04d3e4",
				        "d2a1ed44-6cca-44d2-9b9c-1c9c1d597093",
				        "df797265-8679-421c-a75c-3540540daf42",
				        "52a558df-2a96-42f6-a954-bab8b79d7786",
				        "cfbb8888-3227-45fc-a4b7-423af170defa",
				        "9720c6de-a181-4f1d-969b-7640cc969eda",
				        "983c7e63-6f35-4cf7-9089-68ef0bed3312",
				        "8fcbfc74-16d0-402f-8c05-2c24f17d6a04",
				        "f3bd6cd0-1c6f-4d4d-9834-0699c377d36d",
				        "f3bd6cd0-1c6f-4d4d-9834-0699c377d36d",
				        "eb64dc01-5f91-412d-98e0-4a59d21c53dc",
				        "5f3a3426-3c96-496e-ba83-0fc471eb734f",
				        "b08536c0-c53d-11ec-a985-a368244ae980",
				        "7ab74b10-82de-4b17-9656-58e865e0e3ea",
				        "a3a55bf9-8a82-4c98-8ebc-cbb264345297",
				        "95316b85-f9a1-4025-8883-af25638923da",
				        "5cff9bcc-7aa3-463a-ac93-316c1bd87b04",
				        "0cd38b7b-a924-4f88-933f-ffe109c8af4d",
				        "300d1447-a758-431d-8e7d-7fa090f1832b",
				        "4087ce2b-e598-4012-86e2-871646c5f993",
				        "96ecd0d3-9351-4fcb-ac50-08c85e36ab26",
				        "8bdf3437-e038-4a93-abdc-00461630f6c3",
				        "14279eef-ef42-44d9-8168-29766786c1f9",
				        "391082c3-968b-47b1-9c92-b5daf008000b",
				        "04faa076-dd53-4a13-89bc-f28092cd9dfa",
				        "699a1020-3dfe-4808-94f6-6db8610f47f5",
				        "bb87147-f9cf-468b-8817-c4ff78e9dd73"
				      ],
				      "readSupportedPlatformsFlagForStaticTabsEnabled": true,
				      "readSupportedPlatformsFlagForConfigTabsEnabled": true,
				      "allowChatAppEntitlementsSyncFromActivity": true,
				      "extensibilityBotAttachmentsEnabled": true,
				      "extensibilityBotAttachmentsEnabledFromPersonalApps": true
				    },
				    "smb": {
				      "useIntentV3API": true
				    },
				    "enableGuardiansReEntryInviteUpdate": true,
				    "media": {
				      "thumbnailGlobalInMemoryCacheEnabled": true,
				      "imageCacheCount": 150,
				      "handleUnauthorizedDownloadRedirect": false,
				      "fontDisabledInAXPAttachement": true,
				      "processingViaV2Approach": true,
				      "videoUploadsEncodingBitrate": 1200,
				      "videoCaptureDuration": 60,
				      "lensMiniStrip": "true",
				      "miniStripCount": 100
				    },
				    "guardianHomePageAppEnabled": true,
				    "fre": {
				      "shouldShowCommunityFREAlert": true
				    },
				    "telemetry": {
				      "minimumSendInterval": 0,
				      "minimumLandscapeSeconds": 3
				    },
				    "lens": {
				      "imageCompressionSetting": 2
				    },
				    "communitiesDeferredDeeplinkEnabled": true,
				    "ux": {
				      "amsThumbnailProfilePhone": "imgpsh_thumbnail_sx",
				      "amsThumbnailProfilePad": "imgo",
				      "accountPlaceholderIconsEnabled": true,
				      "accountAwareToastEnabled": true,
				      "accountAwareToastStayTimeMs": 2000,
				      "accountAwareToastEnabledForTappedNotifications": true
				    },
				    "isParentsContactCardEnabled": true,
				    "chat": {
				      "isSimplifiedComposeEnabled": true,
				      "enableIRISBanner": true,
				      "IRISBannerProductionCampaign": true,
				      "IRISBannerSelfHostCampaign": true,
				      "enableQRCodeForGroups": true,
				      "canShowExpandedReactions": true,
				      "controllerConnectedServicesRoamingEnabled": true,
				      "filesTabUploadEnabled": true
				    },
				    "auth": {
				      "enableAuthWatchdogLogging": true,
				      "middleTierM365S2SEnabled": true,
				      "consumerRegionGmtsEnv": "prod"
				    },
				    "files": {
				      "fileRedirectionToOfficeEnabled": true,
				      "enableTabFileUpload": "true",
				      "uploadChunkSizes": {
				        "2G": 250000,
				        "3G": 250000,
				        "4G": 1000000,
				        "LTE": 1000000,
				        "Wifi": 1000000
				      },
				      "spRootLibraryAvailable": true,
				      "enableVroomFileListing": true,
				      "videoSettingsEnabled": true,
				      "removeFromRecent": true
				    },
				    "messaging": {
				      "disable1PlayerTelemetry": true
				    },
				    "isTasksAdaptiveCardEnabled": true,
				    "whitelistedUserInstallediPadApps": [
				      "c738b607-88dd-4f16-aefe-6a824c65d25d",
				      "4c4ec2e8-4a2c-4bce-8d8f-00fc664a4e5b",
				      "f46ad259-0fe5-4f12-872d-c737b174bcb4",
				      "77258206-eaee-4ff8-a5fe-72300f4b4bbb",
				      "cd2d8695-bdc9-4d8e-9620-cc963ed81f41",
				      "d3d1be68-066c-4967-a74b-9edcf902dcfb",
				      "1850b8bb-76ac-411c-9637-08f7d1812d35",
				      "3586755a-4e4f-4ad2-8846-6f408ede3a19",
				      "7f905be6-3226-4a4c-9c54-ab1edce3c99c",
				      "ac46f19f-f3c5-4415-be1d-182f02f6d53f",
				      "683a2a66-a0bd-4ab1-b9e1-0d09faea8c51",
				      "4783e622-5303-4ea7-a211-ef0dd405da73",
				      "fcc850f5-c210-45a2-9576-4ca4e34b6d09",
				      "361ee822-e020-4e06-afb5-71e60a85fd53",
				      "0557a76b-b5d0-42d6-9edb-3864d8d3d450",
				      "327e83d3-5ab9-490c-a5a0-70600f6e84ac"
				    ],
				    "whitelistediPadAppsToOpenInTeams": [
				      "95de633a-083e-42f5-b444-a4295d8e9314",
				      "19a29a41-cbca-4152-a2af-dd9728ea35f1",
				      "0ae35b36-0fd7-422e-805b-d53af1579093",
				      "f4d81e8e-4500-44c2-8328-9e06cbe037c5",
				      "c738b607-88dd-4f16-aefe-6a824c65d25d",
				      "10aea93d-20cf-44c2-b4a5-284c5ef2e6a5",
				      "b7fad6ce-2e23-4aba-b209-859a59ca230e",
				      "040880f4-0c68-4c38-8821-d5efd2b6ddbe",
				      "26bc2873-6023-480c-a11b-76b66605ce8c",
				      "f46ad259-0fe5-4f12-872d-c737b174bcb4",
				      "77258206-eaee-4ff8-a5fe-72300f4b4bbb",
				      "cd2d8695-bdc9-4d8e-9620-cc963ed81f41",
				      "d3d1be68-066c-4967-a74b-9edcf902dcfb",
				      "29ae87cf-6545-4e79-8093-925d91e4150e",
				      "aa5fe6c5-f91c-45ed-88de-640e235ad21b",
				      "3586755a-4e4f-4ad2-8846-6f408ede3a19",
				      "606f1645-4ee6-4f8d-a94f-54744a8446b6",
				      "7f905be6-3226-4a4c-9c54-ab1edce3c99c",
				      "a622ceb4-b6e2-4557-8218-e22e80975ba4",
				      "627bdb14-de72-4b86-9f12-e8c2654259f4",
				      "4783e622-5303-4ea7-a211-ef0dd405da73",
				      "361ee822-e020-4e06-afb5-71e60a85fd53",
				      "d400ec73-d695-4065-b8c2-102d89c18077",
				      "0557a76b-b5d0-42d6-9edb-3864d8d3d450",
				      "4085da2b-3b84-43ac-b895-dd9ec865a6cc",
				      "327e83d3-5ab9-490c-a5a0-70600f6e84ac"
				    ],
				    "sync": {
				      "pollingToPush": true
				    },
				    "calling": {
				      "isMeetingOptionsOnMeetNowCreationEnabled": true,
				      "enableCallMainStageV2": true,
				      "enableParticipantTrayView": true,
				      "blacklistedBotsInCall": [
				        "28:bdd75849-e0a6-4cce-8fc1-d7c0d4da43e5",
				        "28:07331c9d-bd9a-4d00-bb00-9dcacd105691",
				        "28:123425f9-0c72-4bd8-8814-7cb6b02dfc3f",
				        "28:4be36d18-a394-4f94-ad18-fb20df412d7a",
				        "28:4c072661-d231-483f-b32c-2d305791d32d",
				        "28:e8f1f4bd-f39c-479f-8885-a69ded583534",
				        "28:ae05be75-6c5a-47c0-97b8-8c84fd83880d",
				        "28:0a18c351-466c-4293-87eb-7b08a096b0a1",
				        "28:4c1a6ff1-c702-4652-9991-e0b36d310d19",
				        "28:b1902c3e-b9f7-4650-9b23-5772bd429747",
				        "28:f4693563-c70b-4e4d-bda6-01792aa21440",
				        "28:e32c9418-a835-4eb1-bfb9-733fa74dd6e8",
				        "28:9cd07db6-fab5-438c-8e34-44117fac7650",
				        "28:ab5d1521-415b-4380-82e4-af803fb8bf2d",
				        "28:a53eec89-0b8a-4f98-9c56-8e99ce1c58a3",
				        "28:3d59cb08-f597-4e49-9add-a05f9735152b",
				        "28:8cf0f6d9-65dc-464b-a2cb-8f66a9767358",
				        "28:a8011016-05a6-4f6e-b2b3-26543cf329a0",
				        "28:9fe5a0d5-c286-41f1-a014-67c755902881",
				        "28:e9989ac1-1203-4f1e-a716-07abc621a240",
				        "28:494c14c2-d8bb-41e7-b463-4dd17c3fda60",
				        "28:4b25d9f8-18f5-4d09-a582-cd0a28f63181",
				        "28:b5738585-9037-4ebd-8c03-d9a8bdbb537d",
				        "28:556b15e7-452c-4773-b728-6313eaa47b77",
				        "28:b102ccd8-1925-448b-90a7-b083aba25074",
				        "28:817c2506-de4a-4795-971e-371ea75a03ed",
				        "28:c733a6ab-69c4-4b1d-b660-60048c4dce2f"
				      ]
				    },
				    "MsgAnimations": {
				      "isMsgAnimationsEnabled": true,
				      "animationsList": [
				        "fireworks",
				        "balloons",
				        "heartsRising",
				        "confetti"
				      ]
				    },
				    "groupCreation": {
				      "gttEnabled": true,
				      "Experiment": 1,
				      "smbIntentCustomization": true,
				      "templatesInChatList": [
				        "holidayPlanning",
				        "company",
				        "family"
				      ],
				      "templatesInChatListForIntentBusiness": [
				        "company",
				        "projectCoord"
				      ],
				      "templatesInChatListForIntentPersonal": [
				        "holidayPlanning",
				        "family",
				        "friends"
				      ],
				      "templatesInSuggestedGroups": [
				        "holidayPlanning",
				        "family",
				        "friends",
				        "company",
				        "projectCoord",
				        "getTogether",
				        "localCommunity"
				      ],
				      "templatesInSuggestedGroupsForIntentBusiness": [
				        "company",
				        "projectCoord",
				        "getTogether",
				        "holidayPlanning",
				        "friends",
				        "family",
				        "localCommunity"
				      ],
				      "templatesInSuggestedGroupsForIntentPersonal": [
				        "holidayPlanning",
				        "family",
				        "friends",
				        "getTogether",
				        "localCommunity",
				        "company",
				        "projectCoord"
				      ]
				    },
				    "people": {
				      "enableAliasDiscoverabilitySettings": true,
				      "enableUserDefaultProfilePicture": true,
				      "shouldShowGroupParticipantsInSearch ": true,
				      "deviceContactsInGlobalSearchEnabled": true,
				      "enableABContactsSync": true,
				      "addressBookUploadBatchCount": 200,
				      "enableDisplayNameOveride": false,
				      "extendedUserMailsAndPhonesSearchEnabled": true,
				      "deviceContactsSearchEnabled": true,
				      "instantScdLookupEnabled": true,
				      "enableAddContactOnMessageSent": true,
				      "enablePresenceUI": false,
				      "enableBlockContact": true,
				      "enableMiniProfilesSync": true,
				      "enableUpdateAvatar": true,
				      "enableDeleteAvatar": true,
				      "enableEditDisplayName": true,
				      "maxQuarantineCounter": 10,
				      "enableInviteFree": true,
				      "enforceUserLastSyncTimeEnabled": true,
				      "userSyncIntervalInDays": 1,
				      "scdPingIntervalInDays": 15,
				      "middleTierProfileS2SEnabled": true
				    },
				    "consumerGroup": {
				      "syncMissingCgEnabled": true
				    },
				    "newGroupWelcomeScreenType": 1,
				    "isUntitledGroupCreationEnabled": true,
				    "meetings": {
				      "meetingDetailsMeetingOptionsEnabled": true
				    },
				    "sharedLinks": {
				      "dashboardSharedLinksEnabledPath": true
				    },
				    "isTasksTabEnabled": true,
				    "isChatTasksEnabled": true,
				    "Feedback": {
				      "enableOcvFeedback": true,
				      "disableShakeAndSend": true,
				      "lifeFeedbackUrl": "https://aka.ms/teamslifefeedback"
				    },
				    "user": {
				      "supportsPutAggregatedAction": false
				    },
				    "nps": {
				      "isFloodgateEnabled": true,
				      "audienceGroup": "Production"
				    },
				    "enableJoinLinkInviteInExistingChats": true,
				    "flw": {
				      "isFLWPresenceAuditServiceEnabled": true
				    },
				    "Location": {
				      "enableLiveGeofences": true,
				      "enableLiveGeofencesSearch": true,
				      "enableLiveGeofencesTrigger": true,
				      "sessionRemoteSyncMinimumInterval": 259200,
				      "enableLiveLocation": true,
				      "enableBeaconUploader": true,
				      "enableBeaconTelemetry": true,
				      "enablePassiveTracking": true,
				      "enableIndefiniteSharing": true,
				      "familySettingsRefreshMinimumInterval": 86400,
				      "enableTeamsHttp": true,
				      "enableActivityFeed": true,
				      "serviceUrlOverride": "https://teams.live.com/api/location/prod/",
				      "batterySettings": {
				        "pushMuteThreshold": 20,
				        "pushMuteDuration": 1800,
				        "activeTrackingThreshold": 40
				      },
				      "durationOptions": [
				        30,
				        1440
				      ]
				    },
				    "presence": {
				      "TFLPresenceEnabled": true
				    },
				    "channel": {
				      "channelFollowIconUpdateEnabled": true
				    },
				    "atp": {
				      "enableATPViaMT": true
				    },
				    "whatsNewExperienceEnabled": true,
				    "whatsNewUnreadDotEnabled": false,
				    "whatsNewNotificationEnabled": false
				  },
				  "SkypeTelemetry": {
				    "kpi_inapp_activity_ended": {
				      "enabled": true
				    },
				    "kpi_inapp_activity_start": {
				      "enabled": true
				    },
				    "kpi_call_ended": {
				      "enabled": true
				    },
				    "kpi_message_viewed": {
				      "enabled": true
				    },
				    "kpi_longpoll_complete": {
				      "percentage": 0.01
				    },
				    "kpi_longpoll_failed": {
				      "percentage": 0.01
				    },
				    "kpi_message_sent": {
				      "enabled": true,
				      "percentage": 10
				    },
				    "kpi_message_delivered": {
				      "enabled": true,
				      "percentage": 10
				    },
				    "kpi_chatsync_complete": {
				      "enabled": true,
				      "percentage": 0.01
				    },
				    "kpi_pushnotif_delivered": {
				      "enabled": true
				    },
				    "kpi_pushnotif_displayed": {
				      "enabled": true
				    },
				    "kpi_badge_count_state": {
				      "enabled": true
				    },
				    "kpi_client_init": {
				      "enabled": false
				    },
				    "kpi_client_ready_state_time": {
				      "enabled": false
				    },
				    "kpi_push_to_sync_complete": {
				      "enabled": true
				    },
				    "kpi_search_request": {
				      "enabled": true
				    },
				    "kpi_postsearch_action": {
				      "enabled": true
				    },
				    "kpi_contacts_sync_complete": {
				      "enabled": true
				    },
				    "kpi_chat_service_connection": {
				      "enabled": true
				    },
				    "kpi_message_sent_retry": {
				      "enabled": true
				    },
				    "kpi_chatsync_failed": {
				      "enabled": true
				    },
				    "file_sent": {
				      "enabled": true
				    },
				    "file_received": {
				      "enabled": true
				    },
				    "log_crash_sent": {
				      "enabled": true
				    },
				    "contacts_sync_start_time": {
				      "enabled": true
				    },
				    "contacts_sync_end_time": {
				      "enabled": true
				    },
				    "kpi_user_activity_started": {
				      "enabled": false
				    },
				    "client_heartbeat": {
				      "enabled": false
				    }
				  },
				  "SkypeTransport": {
				    "DTLSPreferGCM": true,
				    "AvoidAggressiveNomination": true
				  },
				  "SkypeTRAP": {
				    "SkypeToAadMigration": {
				      "PreferredToken": "Aad"
				    }
				  },
				  "SkypeTXChannel": {
				    "TenantToken": "4b8ac33881b24d1ca8bd468c0d45335f-8efebf49-da48-481b-acee-151c4b7a7cc7-7416"
				  },
				  "SkypeTXNdi": {
				    "hardwareOutBlackMagic": false,
				    "hardwareOutAja": false
				  },
				  "SkypeVideoLibrary": {
				    "RingSettings": {
				      "Web": {
				        "SettingsOverride": {
				          "disabledUFDs": [],
				          "networkQualityUFDTimeoutTime": 5000
				        }
				      }
				    },
				    "ForceXLMeetingIdrThrottle": "0",
				    "ReceivePipeFMBShortCheck": true,
				    "EnablePreviewAnyStrideSupport": "1",
				    "AV1UseInputFrameStride": true,
				    "EnableEarlyCapEnumeration": "true",
				    "AV1DecObuParseCheck": true,
				    "SetCameraReOpenPermission": "2",
				    "EnableLargeMeetingForScreenEncoding": "false",
				    "XLMeetingConfigurations": "IE0200004000HE0140002500GE0080002000EE0040000800CD0025000350BD0015000250BC0005000200BB0001000080",
				    "ForcePACSIforAlphaMask": "1",
				    "HighMotionScreenLadder": "true",
				    "VBSS_PreserveAR": "0",
				    "MLDWaitTimeCompensation": "1",
				    "RenderDelayAvSync": "1"
				  },
				  "SkypeWebMedia": {
				    "mediaAgent": {
				      "test": true,
				      "iceCandidateTransport": "UDP",
				      "stopCallOnAcceptFailure": true,
				      "webrtcStatNetworkDetectionHysteresis": 0.01,
				      "webrtcStatNetworkDetectionBadLevel": 0.16,
				      "webrtcStatNetworkDetectionGoodLevel": 0.12,
				      "diagnostics": {
				        "sideBySide": true
				      },
				      "removeRecvStreamOnEnded": true,
				      "enableActiveSpeakerBasedDSH": true,
				      "activeSpeaker": {
				        "timeToPromote": 10000
				      },
				      "useSetStreamsForSender": true,
				      "addPrefixForMsidInSdp": false,
				      "webrtcInjectTransportCCAudioMultiparty": true,
				      "allowAccessRawMediaStream": true,
				      "enableNetworkSendQualityUFD": true,
				      "webcv": {
				        "useWasmEffects": true,
				        "powerPreference": "high-performance",
				        "qualityConfig": {
				          "improvementFpsThresholdPercent": 20,
				          "degradationLadder": [
				            {
				              "resolution": {
				                "width": 1920,
				                "height": 1080
				              },
				              "fps": {
				                "min": 15,
				                "max": 30
				              }
				            },
				            {
				              "resolution": {
				                "width": 1280,
				                "height": 720
				              },
				              "fps": {
				                "min": 15,
				                "max": 30
				              }
				            },
				            {
				              "resolution": {
				                "width": 960,
				                "height": 540
				              },
				              "fps": {
				                "min": 15,
				                "max": 30
				              }
				            },
				            {
				              "resolution": {
				                "width": 640,
				                "height": 360
				              },
				              "fps": {
				                "min": 13,
				                "max": 30
				              }
				            },
				            {
				              "resolution": {
				                "width": 426,
				                "height": 240
				              },
				              "fps": {
				                "min": 10,
				                "max": 20
				              }
				            },
				            {
				              "resolution": {
				                "width": 320,
				                "height": 180
				              },
				              "fps": {
				                "min": 10,
				                "max": 20
				              }
				            }
				          ],
				          "statsIntervalSec": 5,
				          "outputFps": {
				            "min": 10,
				            "max": 30
				          },
				          "outputResolution": 720,
				          "preserveResolution": true,
				          "initialLadderResolution": 360
				        },
				        "webGLUnsupportedRenderers": [
				          "Google SwiftShader"
				        ],
				        "webGLRequiredExtensions": [
				          "EXT_color_buffer_float",
				          "WEBGL_debug_renderer_info",
				          "OES_texture_float_linear"
				        ],
				        "usePreheat": false
				      },
				      "noDummyLocalPreview": false,
				      "enableDevicePixelRatio": true,
				      "devices": {
				        "enumerateDevicesAfterADP": true,
				        "blacklist": {
				          "camera": "(ir camera|avstream media device)",
				          "speaker": "stereo mix \\("
				        }
				      },
				      "raiseVideoMuteUfd": true,
				      "requestNewStreamOnUnmute": true,
				      "oneStreamPerDeviceType": true,
				      "specCompliantSimulcast": {
				        "video": {
				          "enabled": true,
				          "layerScaleFactors": [
				            1,
				            2
				          ],
				          "ssrcRange": 99,
				          "enableLocally": true,
				          "allowEnableRemotely": true
				        }
				      },
				      "extmapAllowMixed": true,
				      "enableVla": true,
				      "allowRemoteVla": true,
				      "enableNonAdvVla": true,
				      "useMediaQualityController": true,
				      "layoutControlTimeout": 10000,
				      "isStreamingMatchIsRendering": false,
				      "enforceOpusFmtpMultiparty": {
				        "useinbandfec": 1,
				        "usedtx": 1
				      },
				      "addFmtpToInitialSubscription": true,
				      "h264SubscribeProfile": "64001f",
				      "webrtcVideoCapabilityCheckIntervalMinMultiparty": 5000,
				      "webrtcVideoCapabilityCheckIntervalMaxMultiparty": 5500,
				      "webrtcUnifiedPlanEnabledMultiparty": true,
				      "webrtcSimulcastSessionEnabled": true,
				      "devicePollingAlwaysOn": true,
				      "numVideoChannelsGvc": 12,
				      "webrtcUnifiedPlanEnabled1on1": true,
				      "allowedVideoCodecs1on1": [],
				      "webrtcUseNewStatsApi": true,
				      "useAudioAnalyzer": true,
				      "enableVideoEffects": true,
				      "enableDevtoolsAPI": true,
				      "webrtcStatNetworkDetectionDuration": 10,
				      "webrtcStatNetworkDetectionEnabled": true,
				      "webrtcCameraOpenFs": 3600,
				      "webrtcMultipartyMaxScalingFs": 3600,
				      "webrtcMaxScalingFs": 3600,
				      "webrtcMultiPartyRecvVideoMaxFS": 3600,
				      "webrtcRecvVideoMaxFS": 8160,
				      "webrtcVideoCapabilityMaxFS": 3600,
				      "webrtcRejectedFeatures": "byPass",
				      "webrtcRequiredFeatures": "nonByPass",
				      "webrtcMultiPartyRecvVideoSignaling": true,
				      "enableReconnectChrome": true,
				      "enableReconnectEdge": true,
				      "renegotiationAttempts": 3,
				      "iceDisconnectedTimeoutMs": 30000,
				      "webrtcVideoCapabilityMaxFPS": 3000,
				      "webrtcScreensharingCapabilityMaxFS": 8160,
				      "webrtcScreensharingCapabilityMaxFPS": 1500,
				      "webrtcVideoCapabilityCheckIntervalMin": 20000,
				      "webrtcVideoCapabilityCheckIntervalMax": 30000,
				      "webrtcScreensharingCapabilityCheckIntervalMin": 0,
				      "webrtcScreensharingCapabilityCheckIntervalMax": 0,
				      "enableLocalVideoConstraints": true,
				      "webrtcAudioChannelSignalingFeedback": "app recv:dsh",
				      "webrtcVideoChannelSignalingFeedback": "app send:src recv:src,vc",
				      "webrtcResolutionManagerCooldownTimeout": 15000,
				      "webrtcResolutionManagerRetryDelay": 5000,
				      "webrtcMultiPartyVideoScaling": true,
				      "webrtcSpeakingWhileMutedBadDuration": 3,
				      "reconnectOnDisconnect": false,
				      "webrtcIceGatheringTimeoutMs": 20000,
				      "enableReconnectImprovements1on1": true,
				      "enableReconnectImprovementsMultiparty": true,
				      "webrtcCloseAfterIceFailure": true,
				      "reconnectTimeLimit": 90000,
				      "relayWaitSaneTimeoutMs": 25000,
				      "waitForRelayOnReconnect": true,
				      "iceUdpAddressType": "ip",
				      "iceTcpAddressType": "ip",
				      "iceServerTransport": "tls,tcp,udp",
				      "isSourceIdMappingEnabled": true,
				      "allowMediaLegIdUpdate": true,
				      "webrtcEnabledCustomBwEstimationForVideo": false,
				      "enableH264SpsPpsIdrKeyframe": true,
				      "videoCaptureFreezeTimeout": 5000
				    },
				    "mediaAgent.losingConnectivityTimeoutMs": 2000
				  },
				  "SkypeXT": {
				    "configVariablesAlpha": [
				      {
				        "key": "GMAIL_HOST_ID",
				        "value": "gmail-btn-blue"
				      },
				      {
				        "key": "GMAIL_BTN_COLOR",
				        "value": "#00AFF0"
				      }
				    ],
				    "meetNowWidgetInfo": {
				      "blobPath": "https://secure.skypeassets.com/apollo/0.0.0/meetnowwidget/",
				      "version": "1.0.152"
				    },
				    "disabledCalendarHosts": []
				  },
				  "SMSClient": {
				    "SMSManager": {
				      "Msnp": {
				        "Enabled": 2
				      },
				      "Telemetry": {
				        "Enabled": 1,
				        "AriaToken": "8a2fbd2e7ad744efb18510a1cdb7bb00-24ad87f8-b0e2-43e7-a575-aaea0e4678e2-7461"
				      },
				      "DlrViaMsnp": {
				        "Enabled": 1
				      },
				      "PriceInfoAzure": {
				        "Enabled": 1,
				        "Hostname": "skypesmssfe.trafficmanager.net",
				        "MaxBatchSize": 10,
				        "HttpRetries": 3,
				        "HttpFirstDelay": 3,
				        "HttpNextDelayFactor": 200,
				        "HttpMaxParallelRequests": 2,
				        "HttpConnectionTimeout": 30,
				        "HttpRequestTimeout": 60
				      }
				    }
				  },
				  "SpoolWebConfig": {
				    "test": 12345
				  },
				  "SWG": {
				    "iosIpOverride": [
				      "127.0.0.1"
				    ],
				    "iosFileContent": "ew0KICAiYXBwbGlua3MiOiB7DQogICAgImFwcHMiOiBbXSwNCiAgICAiZGV0YWlscyI6IFsNCiAgICAgIHsNCiAgICAgICAgImFwcElEIjogIjI1RUsyTVdOQTUuY29tLnNreXBlLnNreXBlIiwNCiAgICAgICAgInBhdGhzIjogWyAiTk9UIC9ib3QvKiIsICIqIiBdDQogICAgICB9LA0KICAgICAgew0KICAgICAgICAiYXBwSUQiOiAiMjVFSzJNV05BNS5jb20uc2t5cGUuU2t5cGVGb3JpUGFkIiwNCiAgICAgICAgInBhdGhzIjogWyAiTk9UIC9ib3QvKiIsICIqIiBdDQogICAgICB9LA0KICAgICAgew0KICAgICAgICAiYXBwSUQiOiAiQUw3OThLOThGWC5jb20uc2t5cGUudG9tc2t5cGUiLA0KICAgICAgICAicGF0aHMiOiBbICJOT1QgL2JvdC8qIiwgIioiIF0NCiAgICAgIH0sDQogICAgICB7DQogICAgICAgICJhcHBJRCI6ICJVM0NTNzc5OVdZLmNvbS5za3lwZS5tb2Rlcm4uY29yZWxpYiIsDQogICAgICAgICJwYXRocyI6IFsgIk5PVCAvYm90LyoiLCAiKiIgXQ0KICAgICAgfSwNCiAgICAgIHsNCiAgICAgICAgImFwcElEIjogIlUzQ1M3Nzk5V1kuY29tLnNreXBlLm1vZGVybi5pbnRlcm5hbCIsDQogICAgICAgICJwYXRocyI6IFsgIk5PVCAvYm90LyoiLCAiKiIgXQ0KICAgICAgfSwNCiAgICAgIHsNCiAgICAgICAgImFwcElEIjogIkxFMkpLM00yVDQuY29tLnNreXBlLm1vZGVybi5kZWJ1ZyIsDQogICAgICAgICJwYXRocyI6WyAiTk9UIC9ib3QvKiIsICIqIiBdDQogICAgICB9LA0KICAgICAgew0KICAgICAgICAiYXBwSUQiOiAiVTNDUzc3OTlXWS5jb20uc2t5cGUubW9kZXJuLmRvZ2Zvb2QiLA0KICAgICAgICAicGF0aHMiOlsgIk5PVCAvYm90LyoiLCAiKiIgXQ0KICAgICAgfSwNCiAgICAgIHsNCiAgICAgICAgImFwcElEIjogIjVCTlJIVjhIWTguY29tLnNreXBlLnNhcmwuZGVidWciLA0KICAgICAgICAicGF0aHMiOlsgIk5PVCAvYm90LyoiLCAiKiIgXQ0KICAgICAgfSwNCiAgICAgIHsNCiAgICAgICAgImFwcElEIjogIlUzQ1M3Nzk5V1kuY29tLnNreXBlLmNvbW11bmljYXRpb25zLmRlYnVnIiwNCiAgICAgICAgInBhdGhzIjpbICJOT1QgL2JvdC8qIiwgIioiIF0NCiAgICAgIH0NCiAgICBdDQogIH0NCn0NCg==",
				    "UrlGeneratorService": {
				      "IsEnabled": true,
				      "Host": "api.scheduler.skype.com",
				      "Port": 443,
				      "Endpoints": {
				        "Threads": "/threads"
				      }
				    },
				    "WebLauncher": {
				      "BaseUrl": "https://join.skype.com/launch/"
				    },
				    "isEligible": false,
				    "allowAll": true
				  },
				  "TargetingVersioningTest": {
				    "CompassFMVersion": 1
				  },
				  "TeamsClientCommon": {
				    "cloudEnvironment": "Public",
				    "endpoints": {
				      "SchedulingServiceBaseUrl": "https://api.scheduler.teams.microsoft.com/",
				      "SCTAriaCollectorUri": "https://ic3.events.data.microsoft.com/Collector/3.0/"
				    },
				    "calling": {
				      "helpUrlForBroadcastBlockAnon": "https://go.microsoft.com/fwlink/?linkid=2149542&clcid=0x409"
				    },
				    "meetingTenantIdToName": "{\"123\": \"TenantTest1\", \"234\": \"TenantTest2\",\"73588a2a-d95b-4846-8dc4-5c6bbdfc3a72\": \"CES\",\"9ed72ea6-487f-4eb2-a8c6-dc36e8136aeb\": \"SFF SWITCH 2020\",\"4c00d031-a9ba-448e-9f5c-df8e4f2ef4ea\": \"SFF SWITCH 2020\"}"
				  },
				  "TeamsFLWAndroidProd": {
				    "isAATestEnabled": false,
				    "instantShiftGroupChatEnabled": true
				  },
				  "TeamsFLWIOSProd": {
				    "shifts": {
				      "isAATestFlagEnabled": false,
				      "isSHBackOffThrottlerEnabled": true
				    }
				  },
				  "TeamsVerticalsTelehealth": {
				    "UI_SettingsStorageEnabled": false
				  },
				  "test802": {
				    "a": 456
				  },
				  "TestAbhijit": {
				    "WalkieTalkie": {
				      "SupportedBleHeadsetNamePrefixes": [
				        "foo",
				        "bar"
				      ]
				    }
				  },
				  "TestJsonFormatter": {
				    "RegionGtms": {
				      "MessagingFrontEndS2S": "",
				      "BvdS2S": ""
				    }
				  },
				  "TrouterClientCorelib": {
				    "MakeConnIdPermanent": true,
				    "ClientTelemetryEventEnabled": {
				      "edf_trouter_client_connected": true,
				      "edf_trouter_client_disconnected": true,
				      "edf_trouter_client_request": true,
				      "edf_trouter_client_response": true,
				      "edf_trouter_client_connect_failure_prolonged": true,
				      "edf_trouter_client_log_error": true,
				      "edf_trouter_client_websocket_connect_result": false,
				      "edf_trouter_client_host_and_listener_events": true,
				      "edf_trouter_client_event": true,
				      "edf_trouter_client_connect_failed": false,
				      "edf_trouter_client_internetconnectivity_success": false
				    },
				    "ClientTelemetryLogLevel": "LOG_INFO",
				    "TrouterConnectionUrl": "{0}",
				    "ClientPingIntervalMilliSecs": 55000,
				    "TotalConnectedEventsToLog": 16,
				    "TotalConnectedJsonSetsToLog": 3,
				    "ConnectedEventInvalidDataThreshold": 200000000,
				    "CheckConnectionTimeOutInMilliSecs": 8000,
				    "SwitchConnectionOnKeepAliveFailure": false,
				    "ConnectionTimeoutMilliseconds": 40000,
				    "UseExternalSocketFactory": false,
				    "MinimumOnDemandClientPingIntervalMilliSecs": 0,
				    "EnableWebSocket": true,
				    "EnableXhr": true,
				    "LongPollPollingIntervalMilliSecs": 40000,
				    "ReuseTlsSession": false,
				    "SingleStrandMode": 1
				  },
				  "TrouterJScriptClient": {
				    "TelemetryEnabled": true,
				    "ClientTelemetryEventEnabled": {
				      "trouter_js_client_connected": true,
				      "trouter_js_client_disconnected": true,
				      "trouter_js_client_error": true,
				      "trouter_js_client_progress": true
				    }
				  },
				  "Headers": {
				    "ETag": "\"YXloyURgY3CuA/YdnoHPV6EwIX837VCZ/+8zgPxaWFM=\"",
				    "Expires": "Wed, 16 Nov 2022 00:13:07 GMT",
				    "CountryCode": "CA",
				    "StatusCode": "200"
				  },
				  "ConfigIDs": {
				    "AcsCallingSDK": "P-R-99334-2-4",
				    "AcsCallingSDKWeb": "P-R-1052712-1-3,P-R-1041638-1-4,P-R-1016834-1-3,P-R-1016529-1-3,P-R-1015751-1-4,P-R-1010697-1-8,P-R-117516-1-5,P-R-115926-3-16,P-R-94049-1-14,P-D-84247-3-13",
				    "AsyncMediaClient": "P-R-18572-1-6,P-R-17927-25582-2,P-R-17992-25804-5,117336,108902,P-D-4028-19804-20",
				    "ClientLogin": "P-D-15373-22035-32",
				    "ConsumerEntitlement": "P-E-27431-2-7,P-R-42155-7-10,P-R-22129-1-10,P-D-22920-4-21,P-D-22449-1-5,P-D-20701-1-22,P-D-20674-1-3,P-D-20673-1-59",
				    "ConsumerEntitlementCampaigns": "P-D-20213-1-36",
				    "CQF": "P-D-1003116-1-1,P-D-75995-1-4",
				    "DebugabilitySquad": "P-R-22273-1-18,P-D-22621-1-8,P-D-22622-1-6",
				    "ECS": "P-R-76663-1-2,P-D-81604-1-2",
				    "ECS_Scorecards_Test": "P-E-75526-C1-3",
				    "ECSCONFIG": "P-R-17919-25564-17,P-D-17910-25541-3,112127",
				    "JennyTest2": "P-E-76898-2-4",
				    "Join": "P-D-28714-1-6",
				    "JoinLauncher": "113355,113356",
				    "LearningAppMobile": "P-R-1025387-10-7,P-R-1019887-10-11,P-R-1015931-10-8,P-R-1012734-1-4,P-R-1008604-10-7,P-R-1009790-10-8,P-R-117676-10-12,P-R-107491-10-12,P-R-99608-10-7,P-R-96491-10-9,P-R-88356-10-7,P-R-89607-10-13,P-R-88364-10-6,P-R-87887-10-12,P-R-79285-10-56,P-R-71628-10-62",
				    "MDN_MIDDLELANE_TEAMS": "P-D-1009217-3-11",
				    "MDN_TRAP": "P-R-62161-2-37,P-D-5047-25517-137",
				    "MDNRAP": "P-E-18117-26159-4,118460,115097,P-D-17817-25261-2,115410",
				    "MediaAgent": "P-R-1002758-10-12,P-D-68276-1-2",
				    "MicrosoftTeamApprovals": "P-R-1044556-10-13,P-R-1035881-10-9,P-R-1034258-10-18,P-R-1034004-10-16,P-R-1026282-11-15,P-R-1001453-10-18,P-R-1020408-10-10,P-R-1017758-8-15,P-R-1016631-10-15,P-R-1008652-10-10,P-R-1001680-10-27,P-R-1000981-10-25,P-R-115999-10-28,P-R-113719-10-19,P-R-111670-10-18,P-R-110628-10-11,P-R-110483-10-18,P-R-109155-4-12,P-R-106606-12-17,P-R-100554-2-18,P-R-99901-10-13,P-R-98971-10-13,P-R-96172-10-19,P-R-95674-15-44,P-R-94749-9-10,P-R-94224-10-13,P-R-90056-10-42,P-R-83888-10-15,P-R-83075-10-14,P-R-82904-10-19,P-R-81622-10-17,P-R-81580-10-24,P-R-77226-10-24,P-R-74994-10-11,P-R-74993-10-21,P-R-74801-10-10,P-R-73793-10-47,P-R-73190-10-9,P-R-69653-11-15,P-R-69035-11-31,P-R-69030-1-16,P-R-68608-10-7,P-R-68937-10-75,P-R-68473-10-4,P-R-65568-10-8,P-R-67490-10-12,P-R-66421-10-56,P-R-63643-1-7,P-R-63120-1-9,P-R-62477-2-4,P-R-62209-2-30,P-D-61939-1-49",
				    "MicrosoftTeamLearning": "P-R-1049825-1-5,P-R-1048544-1-6,P-R-1051041-2-2,P-R-1051067-1-3,P-R-1047946-1-3,P-R-1051289-1-2,P-R-1050424-2-3,P-R-1046279-1-7,P-R-1048740-1-3,P-R-1048193-1-3,P-R-1048201-1-4,P-R-1048200-1-3,P-R-1043586-1-9,P-R-1046109-2-3,P-R-1045540-1-3,P-R-1044167-1-2,P-R-1044093-1-4,P-R-1043626-10-6,P-R-1043622-2-9,P-R-1042967-1-6,P-R-1042036-1-3,P-R-1042074-1-2,P-R-1042043-2-10,P-R-1040983-1-2,P-R-1040935-1-14,P-R-1040506-10-7,P-R-1039863-2-7,P-R-1039670-1-4,P-R-1039137-1-2,P-R-1038872-1-5,P-R-1021805-1-4,P-R-1036832-11-8,P-R-1030210-2-5,P-R-1035289-2-18,P-R-1034305-1-18,P-R-1034096-2-3,P-R-1003485-2-3,P-R-1030173-2-3,P-R-1033422-1-4,P-R-1029554-1-5,P-R-1033464-1-16,P-R-114288-1-5,P-R-1028593-12-9,P-R-1030159-2-10,P-R-1030157-10-7,P-R-1016583-1-4,P-R-1027490-10-7,P-R-1026454-1-3,P-R-1026765-1-3,P-R-1026027-1-4,P-R-1022014-1-13,P-R-1018453-1-6,P-R-1023641-1-12,P-R-114299-1-5,P-R-1023587-1-4,P-R-1023397-1-7,P-R-1020899-1-4,P-R-1019481-1-4,P-R-1020898-1-5,P-R-1020443-10-10,P-R-1013111-1-17,P-R-1020224-1-2,P-R-1019875-1-13,P-R-1019528-1-3,P-R-1010835-12-41,P-R-1018489-11-4,P-R-1018245-1-4,P-R-1015921-2-9,P-R-1008952-5-11,P-R-1015932-10-3,P-R-1015621-1-7,P-R-1015438-10-12,P-R-1014086-1-6,P-R-1014306-1-4,P-R-1000809-2-30,P-R-1010216-10-14,P-R-1011045-1-7,P-R-1010686-1-6,P-R-1009992-10-20,P-R-1005769-7-8,P-R-1007246-2-10,P-R-1007490-10-11,P-R-1002209-1-8,P-R-1006862-10-15,P-R-1006411-1-4,P-R-1005539-10-11,P-R-1006298-1-4,P-R-111981-1-8,P-R-111166-10-18,P-R-1006245-1-3,P-R-1005047-2-15,P-R-1005497-1-4,P-R-1005352-1-2,P-R-1001263-1-9,P-R-1000240-1-12,P-R-1001146-1-5,P-R-1001260-1-3,P-R-1000961-4-5,P-R-1000545-10-6,P-R-115830-1-10,P-R-113445-1-11,P-R-112731-1-4,P-R-118312-1-5,P-R-118233-1-4,P-R-118141-1-5,P-R-117960-8-8,P-R-98775-1-4,P-R-116072-10-10,P-R-116429-1-19,P-R-114121-1-2,P-R-111123-1-2,P-R-108165-1-5,P-R-116256-10-6,P-R-115818-10-8,P-R-115204-20-19,P-R-115050-6-10,P-R-113164-1-9,P-R-113481-1-5,P-R-112733-1-2,P-R-112734-1-2,P-R-112013-1-6,P-R-110871-1-15,P-R-110880-11-13,P-R-110691-1-2,P-R-109956-1-2,P-R-100159-10-4,P-R-109573-2-8,P-R-109131-1-5,P-R-107699-1-5,P-R-104379-3-21,P-R-99589-1-2,P-R-99433-6-9,P-R-98164-1-2,P-R-97009-1-19,P-R-97523-1-5,P-R-93466-2-6,P-R-96673-1-18,P-R-96864-1-18,P-R-96674-1-6,P-R-95139-1-6,P-R-95023-10-13,P-R-94036-14-16,P-R-92567-10-9,P-R-93332-2-12,P-R-92145-2-6,P-R-91992-2-3,P-R-91394-2-24,P-R-89656-4-6,P-R-90986-1-6,P-R-91032-1-7,P-R-91197-1-15,P-R-91020-2-4,P-R-90915-2-7,P-R-90887-2-6,P-R-90917-2-4,P-R-90850-2-7,P-R-88102-2-18,P-R-85879-10-17,P-R-87289-3-23,P-R-87096-10-10,P-R-86710-2-3,P-R-81198-10-14,P-R-80844-10-20,P-R-78636-10-43,P-R-79526-10-20,P-R-79519-1-11,P-R-78446-1-16,P-R-74535-10-6,P-R-74090-10-2,P-R-70130-10-22,P-D-1030425-10-1,P-D-1030423-10-1,P-D-115348-10-1",
				    "MicrosoftTeamsClientAndroid": "P-X-1005891-1-3,P-R-1050298-5-4,P-R-1041988-5-22,P-R-1041987-5-21,P-R-1041816-5-21,P-R-1040687-5-15,P-R-1040171-5-15,P-R-1040113-5-14,P-R-1036781-5-18,P-R-1035221-5-13,P-R-1034236-5-20,P-R-1030252-5-18,P-R-1026111-5-12,P-R-1025338-5-14,P-R-1024900-5-22,P-R-1022161-5-11,P-R-1018467-5-24,P-R-1020419-5-2,P-R-1017695-5-13,P-R-1017450-5-14,P-R-1016835-5-23,P-R-1015904-5-16,P-R-1012699-5-12,P-R-1008314-5-12,P-R-1007451-9-22,P-R-1007235-5-21,P-R-1005456-5-12,P-R-1000673-8-16,P-R-116492-5-10,P-R-115104-5-17,P-R-111879-5-11,P-R-109151-5-13,P-R-105589-5-13,P-R-105586-5-12,P-R-97482-7-4,P-R-97233-5-19,P-R-96413-5-4,P-R-95301-5-18,P-R-93729-5-25,P-R-90476-5-10,P-R-88575-5-15,P-R-86313-5-12,P-R-86131-13-58,P-R-84682-5-8,P-R-82991-5-2,P-R-82309-5-11,P-R-81639-5-13,P-R-80860-5-4,P-R-80731-5-8,P-R-80480-5-11,P-R-80482-5-13,P-R-79581-5-4,P-R-79520-5-10,P-R-76274-5-31,P-R-76193-5-7,P-R-75897-5-9,P-R-72789-5-10,P-R-72112-5-3,P-R-71912-1-3,P-R-71890-5-9,P-R-62704-1-11,P-R-71063-5-8,P-R-70347-6-2,P-R-70164-5-5,P-R-68825-5-9,P-R-64856-5-14,P-R-68573-5-8,P-R-67852-6-7,P-R-67309-5-5,P-R-67308-5-5,P-R-66980-6-3,P-R-65435-5-4,P-R-65134-1-3,P-R-64358-5-11,P-R-64050-5-6,P-R-63827-5-10,P-R-63673-5-8,P-R-63659-5-7,P-R-62973-6-18,P-R-62296-5-19,P-R-60824-5-13,P-R-60631-5-3,P-R-60564-5-7,P-R-59924-1-6,P-R-59559-5-10,P-R-59555-5-64,P-R-58812-5-4,P-R-56684-5-7,P-R-56622-5-8,P-R-56181-5-6,P-R-56062-5-16,P-R-55818-6-50,P-R-55734-6-4,P-R-55724-9-4,P-R-55722-9-4,P-R-55719-9-4,P-R-55718-9-4,P-R-55716-9-4,P-R-55713-9-6,P-R-55712-9-4,P-R-55707-9-4,P-R-55705-9-4,P-R-55703-9-4,P-R-55670-9-5,P-R-53428-9-11,P-R-55313-9-3,P-R-55298-1-2,P-R-55277-9-5,P-R-54779-9-13,P-R-53626-9-8,P-R-53436-9-13,P-R-52769-9-10,P-R-51915-19-10,P-R-39387-29-25,P-R-45198-9-6,P-R-36728-10-7,P-R-33066-10-7,P-R-30265-19-23,P-R-26751-9-9,P-R-26378-9-6,P-R-25698-9-11,P-R-25223-9-5,P-R-24803-9-17,P-R-24598-9-7,P-D-55299-3-3,P-D-20134-1-6,3870d941:197932",
				    "MicrosoftTeamsEcsPrototype": "P-E-26554-C1-3,P-E-26551-C1-3,P-D-25658-1-5",
				    "MicrosoftTeamsRetailClients": "P-E-96080-C1-3,P-R-112617-6-2,P-R-112615-6-2,P-R-112539-6-2,P-R-112538-6-2,P-R-112637-7-2,P-R-112632-6-2,P-R-112613-7-8,P-R-110718-7-12,P-R-96942-1-4,P-R-96082-5-7,P-R-90632-10-6,P-R-86977-13-8,P-R-82747-10-3,P-R-80501-5-11,P-R-79683-10-4,P-D-47240-6-99",
				    "MicrosoftTeamsRetailIOSClients": "P-R-1028543-6-9,P-R-1026713-5-23,P-R-89254-5-7,P-R-79956-1-3,P-D-69244-1-53",
				    "MicrosoftTeamVivaPulse": "P-D-1049498-1-3",
				    "NancyTest": "P-E-54022-C1-3,P-D-1025474-1-1,P-D-85987-3-3",
				    "Notifications": "P-D-21331-2-9,P-D-8138-12357-7",
				    "ODSP_MEE_Mobile": "P-R-1053351-10-14,P-R-1021828-10-6,P-R-1039418-1-2,P-R-1039179-10-5,P-R-1038913-10-9,P-R-1029888-10-5,P-R-1021552-10-6,P-R-1003382-10-4,P-R-1003010-10-5,P-R-117271-10-4,P-R-113440-8-10,P-R-113424-10-8,P-R-112547-10-3,P-R-111993-10-6,P-R-110759-10-8,P-R-109335-10-6,P-R-106638-10-3,P-R-100944-10-6,P-R-99235-10-3,P-R-97835-10-3,P-R-82015-10-9,P-R-96489-10-8,P-R-95976-10-3,P-R-94656-10-6,P-R-94463-10-3,P-R-93857-8-5,P-R-93728-10-8,P-R-93668-10-3,P-R-92587-10-2,P-R-92458-10-3,P-R-91334-10-6,P-R-85021-10-9,P-R-83560-18-26,P-R-81453-10-14,P-R-75186-10-37,P-D-73826-1-59",
				    "OpConfig": "100762",
				    "OrchestrationTest": "P-R-84600-10-14,P-R-84590-10-14,P-R-83615-10-14,P-R-83596-10-15",
				    "OsamaTest": "P-D-38649-1-2",
				    "PeopleImport": "P-D-38632-1-4",
				    "PeopleRecommendation": "P-R-37188-2-16,P-D-18870-1-13",
				    "PeopleSearch": "P-R-82995-7-9,P-D-17755-25095-10",
				    "PortalWebClient": "P-R-55904-2-11,P-D-5041-9166-237",
				    "PstnDynamicRouting": "P-R-1042956-35-35",
				    "PstnHub": "P-R-1044897-2-9,P-R-115414-2-5,P-R-109621-2-6,P-R-105587-1-3,P-R-91520-2-56,P-R-88235-1-19,P-R-88233-1-36,P-R-66954-1-7,P-R-62994-1-22,P-R-55797-8-8,P-R-55796-8-8,P-R-42072-10-12,P-R-38575-11-39,P-R-38574-11-13,P-R-29715-10-92,P-R-29716-10-94,P-R-25727-70-136,P-R-25728-30-90,P-R-25680-90-86,P-D-48963-1-2,P-D-25559-1-19,P-D-23144-1-21",
				    "RichNotifications": "P-R-77992-1-17",
				    "S4L": "P-R-31525-2-6",
				    "S4L_Caap": "P-R-45125-7-6,P-R-26062-2-24,P-R-25374-2-12,P-R-23115-2-12",
				    "S4L_CMC": "P-R-116079-7-3,P-R-112779-7-5,P-R-93671-8-16,P-R-67295-7-8,P-R-64790-9-69,P-R-63740-7-4,P-R-55224-7-12,P-R-54489-7-5,P-R-52188-7-11,P-D-74721-7-1,P-D-28642-2-1",
				    "S4L_Commerce": "P-R-28486-1-2,P-D-39525-1-3,P-D-36721-1-3",
				    "S4L_Config": "P-R-72417-7-29,P-R-41939-8-16,P-R-27606-4-5,P-R-26957-2-3,P-R-25158-6-24,P-D-72517-1-1,P-D-72516-2-1,P-D-72515-4-1,P-D-39496-7-1,P-D-31665-1-1",
				    "S4L_Contacts": "P-R-39979-7-12,P-R-32536-21-19,P-R-36743-7-12,P-D-88092-2-1,P-D-39763-7-1,P-D-39497-7-1,P-D-33803-1-1,P-D-20304-1-61",
				    "S4L_Cortana": "P-R-45126-7-5",
				    "S4L_Engagement": "P-D-45603-3-2,P-D-35592-1-7,P-D-35597-3-10,P-D-21990-1-40",
				    "S4L_Feedback": "P-D-28683-1-2",
				    "S4L_Messaging": "P-E-1043648-2-7,P-R-1015759-7-11,P-R-88226-7-3,P-R-68517-7-3,P-R-29103-2-9,P-R-28428-2-14,P-R-28126-2-27,P-R-27950-2-15,P-R-27802-2-14,P-R-27469-2-44,P-R-27536-2-8,P-R-26785-2-16,P-R-24261-2-3,P-R-22697-2-7,P-D-1024180-1-1,P-D-78166-5-4,P-D-72811-1-1",
				    "S4L_Onboarding": "P-R-37529-4-7,P-R-37012-3-4,P-R-33622-3-5,P-R-33621-3-6",
				    "S4L_Search": "P-R-27633-1-14,P-D-22650-1-19",
				    "S4L_SISU": "P-D-35727-1-2",
				    "S4L_UI": "P-R-47000-2-5,P-R-37324-7-6,P-R-26606-8-15,P-R-24630-1-3",
				    "SCT": "P-D-68121-1-2,P-D-20968-7-13,P-D-20225-1-9",
				    "Segmentation": "P-R-1050900-1-8,P-R-1040659-1-2,P-R-79661-1-10,P-R-41544-1-5,P-R-25076-1-8,P-R-21476-3747218-1",
				    "SkylibInfrastructure": "P-R-1011620-1-2,P-R-96285-6-11,P-R-107860-7-4,P-R-78525-1-3,P-R-68255-1-4,P-R-67379-1-5,P-R-64744-1-4,P-R-64741-1-4,P-R-63121-6-6,P-R-58928-2-7,P-R-58929-3-5,P-R-58914-1-13,P-R-58994-10-8,P-R-58564-1-2,P-R-54968-19-6,P-R-50859-9-11,P-R-43047-22-3,P-R-38010-11-19",
				    "SkypeAudioLibrary": "P-R-1053575-1-5,P-R-1034141-4-16,P-R-1016281-9-24,P-R-106314-1-2,P-R-78316-6-19,P-R-77767-1-6,P-R-15396-22088-2,P-D-1049423-1-2,P-D-1034101-1-2,P-D-104493-1-3,P-D-79226-1-1,P-D-70366-1-2,P-D-66358-1-4,P-D-62607-1-1,P-D-49739-1-8,P-D-47132-1-4,P-D-22526-1-9,P-D-22453-1-5,P-D-22193-1-5,P-D-19915-1-10,P-D-19507-1-9,P-D-19137-1-8,118059",
				    "SkypeBilling": "117294",
				    "SkypeCalling": "P-R-1047052-8-4,P-R-1039059-5-7,P-R-1018335-5-10,P-R-1016733-5-7,P-R-1005564-7-13,P-R-1003135-17-21,P-R-115161-5-7,P-R-116683-11-23,P-R-115144-1-21,P-R-113344-6-7,P-R-112853-7-5,P-R-95332-6-19,P-R-91768-6-5,P-R-88151-6-12,P-R-86497-7-6,P-R-85542-7-6,P-R-85153-6-5,P-R-83268-6-11,P-R-77280-5-12,P-R-77279-6-8,P-R-75937-8-7,P-R-70853-1-3,P-R-70727-7-9,P-R-70729-5-4,P-R-67475-7-10,P-R-67550-8-10,P-R-62406-6-12,P-R-62405-6-28,P-R-60708-6-11,P-R-60618-8-13,P-R-59994-7-8,P-R-60213-7-13,P-R-59725-10-11,P-R-50188-6-29,P-R-53880-7-7,P-R-53782-7-11,P-R-49520-8-5,P-R-47208-4-51,P-R-43173-6-16,P-R-28469-9-41,P-R-25415-4-36,P-R-21505-2-40,P-R-21838-1-11,P-D-1028332-1-2,P-D-1018002-6-7,P-D-65471-19-11,P-D-65025-1-2,P-D-48917-1-2,P-D-47707-1-3,P-D-46397-7-4,P-D-43722-1-7,P-D-24792-1-4,P-D-24296-1-1,P-D-23046-1-1,P-D-22705-1-3,P-D-22475-1-6,P-D-21727-1-5,P-R-20743-1-1,P-D-20722-1-15,P-D-19966-1-4,P-D-20107-1-2,P-D-19717-1-1,P-D-19340-1-3,P-D-19114-1-3",
				    "SkypeEngagement": "P-E-1025583-4-6,P-E-1019892-4-4,P-E-1016992-4-5,P-E-1008458-4-5,P-E-91211-4-10,P-E-1003063-4-8,P-E-1005082-4-6,P-E-1005086-4-6,P-E-1005084-4-6,P-E-1003458-4-4,P-E-1003456-4-4,P-E-1003454-C3-4,P-E-116741-4-10,P-E-116626-4-5,P-E-108745-4-4,P-E-64182-5-8,P-E-82871-4-5,P-E-25239-2-9,P-E-48381-4-26,P-E-28017-2-20,P-E-37870-3-6,P-E-37760-4-10,P-E-37860-4-12,P-E-28812-2-6,P-E-24158-4-21,P-E-37351-6-15,P-E-37306-5-5,P-E-37292-6-20,P-E-37085-4-7,P-E-37016-4-9,P-E-31909-2-12,P-E-31552-2-8,P-E-27352-2-7,P-E-27377-2-13,P-E-24439-2-18,P-E-25725-C1-9,P-E-25055-2-4,P-E-23771-4-32,P-E-23585-4-15,P-D-22627-1-8",
				    "SkypeFeedbackAndSupport": "P-D-24646-1-2",
				    "SkypeiOS": "P-R-18991-1-7,P-R-18646-3-7",
				    "SkypeM2": "P-R-25599-2-6,P-R-22835-2-4,P-R-22448-1-8",
				    "SkypeMediaIntelligence": "123763",
				    "SkypeMediaStack": "P-E-1028753-C1-12,P-R-114459-1-3,P-R-109412-1-5,P-R-107428-1-4,P-R-92865-1-2,P-R-89965-1-6,P-R-89852-1-2,P-R-70730-1-2,P-R-70426-1-2,P-R-51811-9-12,P-R-48447-9-12,P-R-45686-1-5,P-R-30121-1-101,P-R-21238-1-3,P-D-1034402-1-1,P-D-51815-1-2",
				    "SkypePersonalization": "109919",
				    "SkypeResourceManager": "P-E-86955-C1-21,P-R-1052879-1-2,P-R-1049433-1-2,P-R-1048249-1-2,P-R-1046879-1-2,P-R-1045226-1-2,P-R-1036852-1-2,P-R-1035740-1-2,P-R-1028734-1-2,P-R-1027351-1-2,P-R-1020287-1-2,P-R-1019394-1-2,P-R-1010690-1-2,P-R-1007547-1-2,P-R-1007546-1-2,P-R-1000757-1-2,P-R-99868-1-2,P-R-99795-1-3,P-R-99345-1-2,P-R-99053-1-2,P-R-98705-1-2,P-R-98132-1-2,P-R-97802-1-2,P-R-97307-1-2,P-R-97301-1-2,P-R-96073-1-2,P-R-94378-1-2,P-R-94082-1-3,P-R-93799-1-2,P-R-93275-1-2,P-R-79274-2-6,P-R-78400-1-5,P-R-78140-1-4,P-R-78016-1-9,P-R-77192-1-3,P-R-71938-1-3,P-R-71643-1-5,P-R-70191-1-5,P-R-69481-1-2,P-R-65315-1-3,P-R-59412-1-5,P-R-55419-1-3,P-R-54478-1-4,P-R-53771-13-276,P-R-48833-1-5,P-R-45414-1-3,P-R-27742-1-8,P-R-26444-1-11,P-D-53333-1-2,P-D-52527-1-2,P-D-51458-1-2,P-D-51059-1-2,P-D-40953-1-2,P-D-27990-1-5,P-D-30029-1-1,P-D-24132-1-3,P-D-21537-2-10,P-D-19893-1-1,P-D-18967-1-1,115685,120830,P-D-15348-21989-16,P-D-12245-18745-2",
				    "SkypeRootTools": "P-R-73139-1-13,P-R-36813-1-10,P-R-38083-10-5,P-R-21112-1-51,P-D-79461-1-5,P-D-18119-26163-12",
				    "SkypeTeamsClientIOS": "P-X-1006485-1-3,P-E-38474-2-3,P-R-1045751-5-14,P-R-1044105-5-13,P-R-1037296-5-14,P-R-1040170-5-14,P-R-1036765-5-15,P-R-1038067-5-8,P-R-1035217-5-13,P-R-1034234-5-22,P-R-1033272-5-19,P-R-1029609-5-3,P-R-1029607-5-3,P-R-1030090-6-13,P-R-1028272-5-9,P-R-1027703-5-12,P-R-1026052-5-18,P-R-1023869-5-18,P-R-1022168-5-11,P-R-1022049-5-25,P-R-1021320-5-15,P-R-1020119-5-13,P-R-1015910-5-15,P-R-1017966-5-6,P-R-1017451-5-16,P-R-1017443-5-14,P-R-1015966-5-9,P-R-1011769-5-16,P-R-1012591-5-6,P-R-1012430-5-12,P-R-1011105-5-13,P-R-1008964-5-4,P-R-1006868-7-26,P-R-117236-5-11,P-R-117281-5-13,P-R-116240-5-15,P-R-113097-5-13,P-R-111360-5-13,P-R-110687-5-16,P-R-99237-5-12,P-R-98409-5-3,P-R-98175-5-3,P-R-96991-5-4,P-R-95702-5-9,P-R-95709-5-5,P-R-95705-5-4,P-R-96585-5-13,P-R-94973-5-25,P-R-93632-5-4,P-R-93295-5-10,P-R-80884-5-6,P-R-86015-5-8,P-R-85342-5-8,P-R-83172-5-20,P-R-84413-5-12,P-R-80481-5-11,P-R-80483-5-12,P-R-78299-5-11,P-R-77661-5-39,P-R-76335-5-4,P-R-75749-5-9,P-R-72223-5-2,P-R-71972-5-3,P-R-71322-5-37,P-R-71066-5-6,P-R-69724-5-6,P-R-69171-5-4,P-R-68797-5-11,P-R-67133-5-12,P-R-67866-5-11,P-R-61972-5-10,P-R-66489-5-9,P-R-63341-5-14,P-R-62237-5-20,P-R-62072-5-11,P-R-61810-5-9,P-R-61330-5-15,P-R-60479-5-11,P-R-59802-5-16,P-R-59562-5-9,P-R-59558-5-79,P-R-58848-5-7,P-R-58811-5-5,P-R-58645-5-25,P-R-58605-5-4,P-R-55721-9-5,P-R-56685-5-7,P-R-56182-5-4,P-R-55833-6-16,P-R-55816-6-23,P-R-55733-6-4,P-R-55725-9-4,P-R-55720-9-4,P-R-55717-9-4,P-R-55715-9-4,P-R-55714-9-4,P-R-55711-9-4,P-R-55710-9-4,P-R-55706-9-4,P-R-55704-9-4,P-R-55668-9-5,P-R-55498-9-11,P-R-53429-9-9,P-R-55278-9-5,P-R-53435-9-13,P-R-52409-9-10,P-R-44939-10-8,P-R-43334-9-16,P-R-37369-10-23,P-D-55630-1-3,47dag628:200405",
				    "SkypeTelemetry": "P-D-19145-1-17",
				    "SkypeTransport": "P-R-103785-1-2,P-D-37851-1-1",
				    "SkypeTRAP": "P-D-1052357-1-7",
				    "SkypeTXChannel": "P-E-18947-C1-7",
				    "SkypeTXNdi": "P-R-74055-1-12",
				    "SkypeVideoLibrary": "P-E-92383-2-6,P-R-1042997-1-2,P-R-1027865-4-6,P-R-1004346-1-5,P-R-1003214-5-10,P-R-111235-1-9,P-R-112066-3-12,P-R-85695-2-16,P-R-86237-1-6,P-R-76912-4-65,P-R-73640-1-5,P-R-71606-1-28,P-R-88482-1-2,P-D-52266-1-1,P-D-49668-1-3,P-D-48612-1-2",
				    "SkypeWebMedia": "P-E-1037344-2-3,P-E-108283-2-3,P-R-1039370-12-7,P-R-1038510-12-12,P-R-1038019-2-7,P-R-1027090-15-11,P-R-1015623-7-17,P-R-1016608-1-4,P-R-1010832-4-6,P-R-1006078-10-30,P-R-1004106-2-9,P-R-1003758-1-3,P-R-115866-12-23,P-R-117515-1-5,P-R-115491-1-8,P-R-112631-1-10,P-R-98638-1-8,P-R-96678-1-9,P-R-95572-37-111,P-R-95395-1-4,P-R-88231-9-17,P-R-87894-4-6,P-R-84874-11-6,P-R-72908-4-20,P-R-79592-2-3,P-R-78209-4-10,P-R-72911-3-21,P-R-72314-22-38,P-R-71423-33-99,P-R-68127-4-7,P-R-40984-9-7,P-D-27831-1-32,P-D-27828-10-38",
				    "SkypeXT": "P-E-20791-2-5,P-R-1002253-8-7,P-R-20769-1-13",
				    "SMSClient": "P-R-16504-26097-32,P-D-16503-23360-7",
				    "SpoolWebConfig": "P-R-78121-13-12",
				    "SWG": "P-E-18277-2-12,119046",
				    "TargetingVersioningTest": "P-D-1008260-5-6",
				    "TeamsClientCommon": "P-D-26811-20-32",
				    "TeamsFLWAndroidProd": "P-E-85487-2-7,P-R-51435-9-7",
				    "TeamsFLWIOSProd": "P-E-85804-2-8,P-R-46708-9-3",
				    "TeamsVerticalsTelehealth": "P-D-40683-1-23",
				    "test802": "P-R-98958-2-5",
				    "TestAbhijit": "P-D-84982-1-3",
				    "TestJsonFormatter": "P-D-60734-1-8",
				    "TrouterClientCorelib": "P-R-45513-1-3,P-R-18423-1-30,P-D-9150-20894-15",
				    "TrouterJScriptClient": "P-D-19873-4-17"
				  },
				  "EventToConfigIdsMapping": {
				    "SkypeMediaStack": {
				      "mdsc_call_quality_feedback": "P-E-1028753-C1-12",
				      "mdsc_mediadiagnostic": "P-E-1028753-C1-12",
				      "mdsc_qoe": "P-E-1028753-C1-12",
				      "mdsc_rmconnectionevent": "P-E-1028753-C1-12",
				      "skypecosi_concore_native_callsignalingagent_callmodality": "P-E-1028753-C1-12"
				    },
				    "SkypeResourceManager": {
				      "mdsc_qoe": "P-R-1052879-1-2,P-R-1049433-1-2,P-R-1048249-1-2,P-R-1046879-1-2,P-R-53771-13-276",
				      "mdsc_rmconnectionevent": "P-R-1052879-1-2,P-R-1049433-1-2,P-R-1048249-1-2,P-R-1046879-1-2,P-R-53771-13-276",
				      "mdsc_call_quality_feedback": "P-R-1052879-1-2,P-R-1049433-1-2,P-R-1048249-1-2,P-R-1046879-1-2,P-R-53771-13-276"
				    },
				    "S4L_Messaging": {
				      "_all_": "P-E-1043648-2-7",
				      "all_notification_app_launched": "P-E-1043648-2-7",
				      "caap_integration": "P-E-1043648-2-7",
				      "calling_call": "P-E-1043648-2-7",
				      "kpi_inapp_activity_start": "P-E-1043648-2-7",
				      "message_sent": "P-E-1043648-2-7",
				      "messaging_action": "P-E-1043648-2-7",
				      "messaging_pes": "P-E-1043648-2-7",
				      "messaging_toast": "P-E-1043648-2-7",
				      "scenario": "P-E-1043648-2-7",
				      "sisu_app_entry": "P-E-1043648-2-7",
				      "messaging_reaction": "P-E-1043648-2-7"
				    },
				    "SkypeAudioLibrary": {
				      "mdsc_qoe": "P-R-1034141-4-16",
				      "mdsc_call_quality_feedback": "P-R-1034141-4-16"
				    },
				    "SkypeVideoLibrary": {
				      "mdsc_qoe": "P-R-1027865-4-6,P-R-76912-4-65",
				      "mdsc_rmconnectionevent": "P-R-1027865-4-6,P-R-76912-4-65",
				      "skypecosi_concore_native_callsignalingagent_callmodality": "P-R-1027865-4-6,P-R-76912-4-65",
				      "mdsc_mediadiagnostic": "P-R-1027865-4-6,P-R-76912-4-65"
				    }
				  }
				}
				""".Replace("{0}", trouterUrl)));
		}
	}
}
